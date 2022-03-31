using System;
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
                OrderEmployeer = OrderEmployeer,
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

        public void Get()
        {

        }

        public List<Order> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Orders
                    .Include(x => x.OrderClient)
                    .Include(x => x.OrderEmployeer)
                    .Include(x => x.OrderDeposit)
                    .ToList();
            }
        }

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                Order order = db.Orders
                    .Include(x => x.OrderClient)
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

        public void Edit()
        {

        }
    }
}
