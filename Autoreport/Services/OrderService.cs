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
                db.Update(order);
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
                    .Include("OrderClient")
                    .Include("OrderEmployeer")
                    .Include("OrderDeposit")
                    .ToList();
            }
        }

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Orders.Remove(db.Orders.Where(order => order.Id == Id).ToList()[0]);
                db.SaveChanges();
            }
        }

        public void Edit()
        {

        }
    }
}
