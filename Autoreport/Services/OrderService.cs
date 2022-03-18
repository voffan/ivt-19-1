using System;
using System.Collections.Generic;
using System.Text;
using Autoreport.Models;
using Autoreport.Database;
using System.Linq;

namespace Autoreport.Services
{
    public class OrderService
    {
        public void Add()
        {

        }

        public void Get()
        {

        }

        public List<Order> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Orders.ToList();
            }
        }

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Orders.Remove(db.Orders.Where(empl => empl.Id == Id).ToList()[0]);
                db.SaveChanges();
            }
        }

        public void Edit()
        {

        }
    }
}
