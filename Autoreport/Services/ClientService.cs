using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autoreport.Database;
using Autoreport.Models;
using Microsoft.EntityFrameworkCore;

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

        public void VaryDebt(Client toClient, bool increase)
        {
            using (DataContext db = Connection.Connect())
            {
                Client client = db.Clients.First(c => c.Id == toClient.Id);

                _ = (increase) ? client.Debt_count++ : client.Debt_count--;
                db.SaveChanges();
            }
        }

        public void VaryOrder(Client toClient, bool increase)
        {
            using (DataContext db = Connection.Connect())
            {
                Client client = db.Clients.First(c => c.Id == toClient.Id);

                _ = (increase) ? client.Order_count++ : client.Order_count--;
                db.SaveChanges();
            }
        }

        public List<Client> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Clients
                    .Include(c => c.Orders)
                    .ToList();
            }
        }

        public Client GetById(int client_id)
        {
            using (DataContext db = Connection.Connect())
            {
                Client client = db.Clients
                    .Where(cl => cl.Id == client_id).ToList()[0];

                return client;
            }
        }

        public Client Get(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                Client client = db.Clients
                    .FirstOrDefault(x => x.Id == Id);
                return client;
            }
        }

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Clients.Remove(db.Clients.Where(empl => empl.Id == Id).ToList()[0]);
                db.SaveChanges();
            }
        }

        public void Edit(Client editingEntity, string lastName, string firstName, string middleName, 
            string phone1, string phone2,
            int debtCount)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Entry(editingEntity).State = EntityState.Modified;
                editingEntity.Last_name = lastName;
                editingEntity.First_name = firstName;
                editingEntity.Middle_name = middleName;
                editingEntity.Phone_number1 = phone1;
                editingEntity.Phone_number2 = phone2;
                editingEntity.Debt_count = debtCount;
                db.SaveChanges();
            }
        }

        public List<Client> Search(params string[] strParams)
        {
            return null;
        }
    }
}
