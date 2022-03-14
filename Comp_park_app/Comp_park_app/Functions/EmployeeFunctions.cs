﻿using System;
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
                c.Employees.Add(employee);
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
