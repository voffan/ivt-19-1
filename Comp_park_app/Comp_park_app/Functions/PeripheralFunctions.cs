using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_park_app.Functions
{
    class PeripheralFunctions
    {
        public void Add(string name, string itemno, Status status, int departmentid, int employeeid)
        {
            Peripheral peripheral = new Peripheral()
            {
               
                Name = name,
                ItemNo = itemno,
                Status = status,
                DepartmentId = departmentid,
                EmployeeId = employeeid
            };

            using (Context c = new Context())
            {
                //... initiate field
                peripheral.Department = c.Departments.Find(departmentid);//Virtual object
                peripheral.Employee = c.Employees.Find(employeeid);

                c.Peripherals.Add(peripheral);
                c.SaveChanges();
            }
        }

        public void Delete()
        {

        }

        public void Edit(int id, string name, string itemno, Status status, int departmentid, int employeeid)
        {
            Peripheral peripheral;
            using (Context c = new Context())
            {
                peripheral = c.Peripherals.Find(id);
                peripheral.Name = name;
                peripheral.ItemNo = itemno;
                peripheral.Status = status;
                peripheral.DepartmentId = departmentid;
                peripheral.EmployeeId = employeeid;

                peripheral.Department = c.Departments.Find(departmentid);
                peripheral.Employee = c.Employees.Find(employeeid);

                c.SaveChanges();
            }
        }
    }
}
