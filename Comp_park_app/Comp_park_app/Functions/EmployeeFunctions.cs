﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Comp_park_app.Functions {
    class EmployeeFunctions {
        public void Add(string name, int departmentid, int positionid, string password) {
            string psw = "";

            if (password.Length > 0) {
                psw = HashPassword(password);
            }
            
            Employee employee = new Employee() {
                Name = name,
                DepartmentId = departmentid,
                PositionId = positionid,
                Password = psw
            };

            using (Context c = new Context()) {
                //... initiate field
                c.Employees.Add(employee);
                c.SaveChanges();
            }
        }

        public void Delete(int index) {
            Employee employee;
            using (Context c = new Context()) {
                employee = c.Employees.Find(index);
                c.Remove(employee);
                c.SaveChanges();
            }
        }

        public void Edit(int id, string name, int departmentid, int positionid) {
            Employee employee;
            using (Context c = new Context()) {
                employee = c.Employees.Find(id);
                employee.Name = name;
                employee.DepartmentId = departmentid;
                employee.PositionId = positionid;
                c.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();
            }
        }

        public static string HashPassword(string password) {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password) {
            var md5 = MD5.Create();
            var pass = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return hashedPassword ==  Convert.ToBase64String(pass);
        }

       
    }
}
