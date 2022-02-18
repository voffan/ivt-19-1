using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autoreport.Database;
using Autoreport.Models;

namespace Autoreport.Services
{
    public class ClientService
    {
        public void Add()
        {
            using (DataContext context = new DataContext())
            {
                Client c = new Client();
                //... initiate fields
                context.Clients.Add(c);
                context.SaveChanges();
            }
        }

        public List<Client> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Clients.ToList();
            }
        }

        public void Get()
        {

        }

        public void Delete()
        {

        }

        public void Edit()
        {

        }
    }
}
