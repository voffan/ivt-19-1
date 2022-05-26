using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;
using Microsoft.EntityFrameworkCore;

namespace Korobki_project.Functions
{
    public class EmployeeFunctions
    {
        public void Add(string name, string login, string password, int positionId, string phoneNumber, string adress, int shiftId)
        {
            Employee employee = new Employee()
            {
                Name = name,
                Login = login,
                Password = password,
                PositionId = positionId,
                PhoneNumber = phoneNumber,
                Adress = adress,
                ShiftId = shiftId,
            };
            using (Context c = new Context())
            {
                c.Employees.Add(employee);
                c.SaveChanges();
            }
        }

        public void Delete(int index)
        {
            Employee comp;
            using (Context c = new Context())
            {
                comp = c.Employees.Find(index);
                c.Remove(comp);
                c.SaveChanges();
            }
        }
        public void Edit(int id, string name, string login, string password, int positionid, string phonenumber, string adress, int shiftid)
        {
            Employee employee;
            using (Context c = new Context())
            {
                employee = c.Employees.Find(id);
                employee.Name = name;
                employee.Login = login;
                employee.Password = password;
                employee.PositionId = positionid;
                employee.PhoneNumber = phonenumber;
                employee.Adress = adress;
                employee.ShiftId = shiftid;
                c.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();
            }
        }
        public static List<Employee> Search(string name)
        {
            using (Context c = new Context())
            {
                var search = c.Employees.Include("Position").Include("Shift")
                    .Where(b => b.Name.Contains(name))
                    .OrderBy(e => e.Name)
                    .ToList();
                return search;
            }
        }
    }
}

