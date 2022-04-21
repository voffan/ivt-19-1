using System;
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
            byte[] salt;
            byte[] buffer2;
            if (password == null) {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8)) {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password) {
            byte[] buffer4;
            if (hashedPassword == null) {
                return false;
            }
            if (password == null) {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0)) {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8)) {
                buffer4 = bytes.GetBytes(0x20);
            }
            return Byte.Equals(buffer3, buffer4);
        }

       
    }
}
