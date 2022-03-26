using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp_park_app.Functions
{
    class EmployeeFunctions
    {
        public void Add(string name, int departmentid, int positionid)
        {
            Employee employee = new Employee()
            {
                Name = name,
                DepartmentId = departmentid,
                PositionId = positionid
            };

            using (Context c = new Context())
            {
                //... initiate field
                employee.Department = c.Departments.Find(departmentid); //Virtual object
                employee.Position = c.Positions.Find(positionid);

                c.Employees.Add(employee);
                c.SaveChanges();
            }
        }

        public void Delete(int index)
        {
            Employee employee;
            using (Context c = new Context())
            {
                employee = c.Employees.Find(index);
                c.Remove(employee);
                c.SaveChanges();
            }
        }

        public void Edit(int id, string name, int departmentid, int positionid)
        {
            Employee employee;
            using (Context c = new Context())
            {
                employee = c.Employees.Find(id);
                employee.Name = name;
                employee.DepartmentId = departmentid;
                employee.PositionId = positionid;

                employee.Department = c.Departments.Find(departmentid);
                employee.Position = c.Positions.Find(positionid);

                c.SaveChanges();
            }
        }
    }
}
