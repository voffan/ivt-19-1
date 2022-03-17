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
        public void Add(string lastName, string firstName, string middleName,
                         string phone1, string phone2
                        )
        {
            Client client = new Client()
            {
                Last_name = lastName,
                First_name = firstName,
                Middle_name = middleName,
                Phone_number1 = phone1,
                Phone_number2 = phone2
            };

            using (DataContext db = Connection.Connect())
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }
        }

        public List<Client> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Clients.ToList();
            }
        }

       /* public List<Client> GetByIds(List<int> ids)
        {
            using (DataContext db = Connection.Connect())
            {
                IQueryable<Client> clients = db.Clients
                    .Where(c => ids.Any(item => item == c.Id));

                return clients.ToList();
            }
        }*/

        public Client GetById(int client_id)
        {
            using (DataContext db = Connection.Connect())
            {
                IQueryable client = db.Clients
                    .Where(cl => cl.Id == client_id);

    
                return (Client)client;
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
