using System;
using System.Collections.Generic;
using System.Text;
using Autoreport.Models;
using Autoreport.Database;
using System.Linq;

namespace Autoreport.Services
{
    public class EmployeeService
    {
        public Employee Login(string username, string pwd)
        {
            return null;
        }

        public void Add()
        {

        }

        public List<Employee> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Employees.ToList();
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
