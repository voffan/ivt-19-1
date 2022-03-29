using System;
using System.Collections.Generic;
using System.Text;
using Autoreport.Models;
using Autoreport.Database;
using Autoreport.UI.Classes;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Autoreport.Services
{
    public class DepositService
    {
        public void Add(string data, int value, DepositType dType, Client clients)
        {
            Deposit deposit = new Deposit()
            {
                Data = data,
                Value = value,
                DepositType = dType,
                Owner = clients
            };

            using (DataContext db = Connection.Connect())
            {
                db.Update(deposit);             
                db.Deposits.Add(deposit);
                db.SaveChanges();
            }
        }

        public void Get()
        {

        }
        public List<Deposit> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
               // var users = from u in db.Users
                //            join c in db.Companies on u.CompanyId equals c.Id
                //            select new { Name = u.Name, Company = c.Name, Age = u.Age };
                return db.Deposits.Include("Owner")
                    .ToList();
            }
        }

        public Deposit GetById(int dep_id)
        {
            using (DataContext db = Connection.Connect())
            {
                Deposit deposit = db.Deposits
                    .Where(dep => dep.Id == dep_id).ToList()[0];


                return deposit;
            }
        }

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Deposits.Remove(db.Deposits.Where(empl => empl.Id == Id).ToList()[0]);
                db.SaveChanges();
            }
        }

        public void Edit()
        {

        }
    }
}
