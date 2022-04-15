using Standings.Database;
using Standings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standings.Functions
{
    public class EmployeeFunctions
    {
        private Employee currentEmployee;
        public static void Add(string login, string password, string fullname, Position position)
        {
            using (Context context = new Context())
            {
                using (Context db = new Context())
                {
                    Employee c = new Employee();
                    c.Login = login;
                    c.Password = password;
                    c.FullName = fullname;
                    c.Position = position;
                    context.Employees.Add(c);
                    context.SaveChanges();
                }
            }
        }
        public void Delete(int Id)
        {
            using (Context db = Connection.Connect())
            {
                Employee c = db.Employees
                    .Where(q => q.Id == Id)
                    .FirstOrDefault();

                db.Employees.Remove(c);
                db.SaveChanges();
            }
        }
        public void Edit(int Id)
        {
            using (Context db = Connection.Connect())
            {
                //Employee c = db.Employees
                    //.Where()
            }
        }
    }
}
