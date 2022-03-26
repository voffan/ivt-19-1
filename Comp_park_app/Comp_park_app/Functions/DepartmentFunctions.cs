using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp_park_app.Functions
{
    class DepartmentFunctions
    {
        public void Add(string name, int number)
        {
            Department department = new Department()
            {
                Name = name,
                Number = number
                
            };

            using (Context c = new Context())
            {
                //... initiate field
                c.Departments.Add(department);
                c.SaveChanges();
            }
        }

        public void Delete()
        {

        }

        public void Edit(int index, string name, int number)
        {
            Department department;
            using (Context c = new Context())
            {
                department = c.Departments.Find(index);
                department.Name = name;
                department.Number = number;
                c.SaveChanges();
            }
        }
    }
}
