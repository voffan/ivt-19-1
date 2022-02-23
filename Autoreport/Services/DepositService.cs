using System;
using System.Collections.Generic;
using System.Text;
using Autoreport.Models;
using Autoreport.Database;
using System.Linq;

namespace Autoreport.Services
{
    public class DepositService
    {
        public void Add()
        {

        }

        public void Get()
        {

        }
        public List<Deposit> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Deposits.ToList();
            }
        }

        public void Delete()
        {

        }

        public void Edit()
        {

        }
    }
}
