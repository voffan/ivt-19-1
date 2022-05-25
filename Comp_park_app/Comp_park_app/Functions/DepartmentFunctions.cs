using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Comp_park_app.Functions {
    public class DepartmentFunctions {
        public void Add(string name, int number) {
            Department department = new Department() {
                Name = name,
                Number = number
                
            };

            using (Context c = new Context()) {
                //... initiate field
                c.Departments.Add(department);
                c.SaveChanges();
            }
        }

        public void Delete(int index) {
            Department department;
            using (Context c = new Context())
            {
                department = c.Departments.Find(index);
                c.Remove(department);
                c.SaveChanges();
            }
        }

        public void Edit(int index, string name, int number) {
            Department department;
            using (Context c = new Context()) {
                department = c.Departments.Find(index);
                department.Name = name;
                department.Number = number;
                c.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();
            }
        }

        public static List<Department> Search(string name) {
            using (Context c = new Context()) {
                var search = c.Departments
                    .Where(b => b.Name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
