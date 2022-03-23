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
                c.Peripherals.Add(peripheral);
                c.SaveChanges();
            }
        }

        public void Delete()
        {

        }

        public void Edit()
        {

        }
    }
}
