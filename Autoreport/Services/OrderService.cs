using System;
using System.Collections.Generic;
using System.Text;
using Autoreport.Models;
using Autoreport.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Autoreport.Services.Errors;

namespace Autoreport.Services
{
    public class OrderService
    {
        public void Add(DateTime OrderDate, DateTime ReturnDate, Employee OrderEmployee, Deposit OrderDeposit, List<Disk> Disks)
        {
            using (DataContext db = Connection.Connect())
            {
                Deposit orderDeposit = db.Deposits
                    .Include(x => x.Owner)
                    .First(x => OrderDeposit.Id == x.Id);

                Client owner = db.Clients.First(x => x.Id == orderDeposit.Owner.Id);

                Order order = new Order()
                {
                    Cost = Disks.Sum(disk => disk.Cost),
                    Order_date = OrderDate,
                    Return_date = ReturnDate,
                    Status = OrderStatus.Proceed,
                    OrderClient = owner,
                    OrderEmployee = db.Employees.First(x => x.Id == OrderEmployee.Id),
                    OrderDeposit = orderDeposit,
                    Disks = db.Disks.Where(x => Disks.Select(x => x.Id).Contains(x.Id)).ToList()
                };

                Connection.clientService.VaryOrder(owner, true);

                foreach (Disk disk in order.Disks)
                {
                    if (disk.Current_count == 0)
                        throw new NotEnoughDisks("Такие диски в данный момент отсутствуют");
                    
                    disk.Current_count--;
                }

                db.Orders.Add(order);
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
                Connection.clientService.VaryDebt(order.OrderClient, true);
                order.Status = OrderStatus.Expired;
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
            }
            else if (currentDate < order.Return_date && order.Status == OrderStatus.Expired)
            {
                Connection.clientService.VaryDebt(order.OrderClient, false);
                order.Status = OrderStatus.Proceed;
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
            }

            return order;
        }

        public Order Get(int orderId)
        {
            using (DataContext db = Connection.Connect())
            {
                Order order = db.Orders
                    .First(x => x.Id == orderId);

                CheckExpiration(order, db);
                return order;
            }
        }

        public List<Order> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Orders
                    .ToList()
                    .Select(x => CheckExpiration(x, db))
                    .ToList();
            }
        }

        public Order CloseOrder(int Id, DataContext db)
        {
            Order order = db.Orders
                .First(order => order.Id == Id);

            Client orderClient = db.Clients.First(x => x.Id == order.OrderClient.Id);
            List<Disk> orderDisks = db.Disks.Where(x => order.Disks.Select(x => x.Id).Contains(x.Id)).ToList();

            Connection.clientService.VaryOrder(orderClient, false);
            Connection.clientService.VaryDebt(orderClient, false);

            foreach (Disk disk in orderDisks)
            {
                disk.Current_count++;
            }

            db.Deposits.Remove(db.Deposits.First(x => x.Id == order.OrderDeposit.Id));

            return order;
        }

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                Order order = CloseOrder(Id, db);

                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        public void Cancel(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                Order order = CloseOrder(Id, db);

                order.Status = OrderStatus.Cancelled;
                db.SaveChanges();
            }
        }

        public void Complete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                Order order = CloseOrder(Id, db);

                order.Status = OrderStatus.Completed;
                db.SaveChanges();
            }
        }

        public void Edit(Order editingEntity, OrderStatus status, DateTime returnDate, Deposit deposit, List<Disk> disks)
        {
            using (DataContext db = Connection.Connect())
            {
                if (status == OrderStatus.Proceed && returnDate < DateTime.Now)
                {
                    throw new DateExpired("Статус заказа установлен в значение 'В процессе', но дата истекла");
                }
                else if (status == OrderStatus.Expired && returnDate >= DateTime.Now)
                {
                    throw new DateNotExpired("Статус заказа установлен в значение 'Просрочен', но дата еще не истекла");
                }

                var order = db.Orders
                    .First(x => x.Id == editingEntity.Id);

                order.Return_date = returnDate;
                order.OrderClient = db.Clients.FirstOrDefault(x => x.Id == deposit.Owner.Id);
                order.OrderDeposit = db.Deposits.FirstOrDefault(x => x.Id == deposit.Id);
                order.Disks = db.Disks.Where(x => disks.Select(y => y.Id).Contains(x.Id)).ToList();

                if (status == OrderStatus.Completed)
                {
                    Connection.clientService.VaryOrder(order.OrderClient, false);

                    foreach (Disk disk in order.Disks)
                    {
                        disk.Current_count++;
                    }
                }

                db.SaveChanges();
            }
        }
    }
}
