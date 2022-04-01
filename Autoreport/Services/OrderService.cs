﻿using System;
using System.Collections.Generic;
using System.Text;
using Autoreport.Models;
using Autoreport.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Autoreport.Services
{
    public class OrderService
    {
        public void Add(DateTime OrderDate, DateTime ReturnDate, Employee OrderEmployeer, Deposit OrderDeposit, List<Disk> Disks)
        {
            Order order = new Order()
            {
                Cost = Disks.Sum(disk => disk.Cost),
                Order_date = OrderDate,
                Return_date = ReturnDate,
                Status = OrderStatus.Proceed,
                OrderClient = OrderDeposit.Owner,
                OrderEmployee = OrderEmployeer,
                OrderDeposit = OrderDeposit,
                Disks = Disks
            };

            using (DataContext db = Connection.Connect())
            {
                db.Entry(order).State = EntityState.Modified;
                db.Orders.Add(order);

                OrderDeposit.Owner.Order_count++;
                db.Entry(OrderDeposit.Owner).State = EntityState.Modified;

                foreach (Disk disk in Disks)
                {
                    if (disk.Current_count == 0)
                        throw new Errors.NotEnoughDisks("Такие диски в данный момент отсутствуют");
                    
                    disk.Current_count--;
                    db.Entry(disk).State = EntityState.Modified;
                }

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Если дата возврата заказа истекла, то меняем статус заказа на "просроченный"
        /// Если дата возврата не истекла, но при это установлен статус "просроченный",
        /// значит заказ был продлен и нужно поменять статус на "в процессе"
        /// </summary>
        /// <param name="order"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public Order CheckExpiration(Order order, DataContext db)
        {
            DateTime currentDate = DateTime.Now;

            if (currentDate > order.Return_date
                && order.Status != OrderStatus.Expired
                && order.Status != OrderStatus.Completed)
            {
                order.Status = OrderStatus.Expired;
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
            }
            else if (currentDate < order.Return_date && order.Status == OrderStatus.Expired)
            {
                order.Status = OrderStatus.Proceed;
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
            }

            return order;
        }

        public Order Get(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                Order order = db.Orders
                    .Include(x => x.Disks)
                    .Include(x => x.OrderClient)
                    .Include(x => x.OrderDeposit)
                    .FirstOrDefault(x => x.Id == Id);

                CheckExpiration(order, db);

                return order;
            }
        }

        public List<Order> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Orders
                    .Include(x => x.OrderClient)
                    .Include(x => x.OrderEmployee)
                    .Include(x => x.OrderDeposit)
                    .Include(x => x.Disks)
                    .ToList()
                    .Select(x => CheckExpiration(x, db))
                    .ToList();
            }
        }

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                Order order = db.Orders
                    .Include(x => x.OrderClient)
                    .Include(x => x.OrderDeposit)
                    .Include(x => x.Disks)
                    .Where(order => order.Id == Id)
                    .ToList()[0];

                Client orderClient = order.OrderClient;
                List<Disk> orderDisks = order.Disks;

                db.Entry(orderClient).State = EntityState.Modified;
                orderClient.Order_count--;

                foreach (Disk disk in orderDisks)
                {
                    db.Entry(disk).State = EntityState.Modified;
                    disk.Current_count++;
                }

                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        public void Edit(Order editingEntity, DateTime returnDate, Deposit deposit, List<Disk> disks)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Entry(editingEntity).State = EntityState.Modified;

                editingEntity.Return_date = returnDate;
                editingEntity.OrderClient = deposit.Owner;
                editingEntity.OrderDeposit = deposit;
                editingEntity.Disks.Clear();
                editingEntity.Disks.AddRange(disks);

                db.SaveChanges();
            }
        }
    }
}
