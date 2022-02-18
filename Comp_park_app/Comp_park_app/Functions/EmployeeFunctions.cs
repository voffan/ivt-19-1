using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_park_app.Functions
{
    class EmployeeFunctions
    {
        public void Add()
        {
            using (Context c = new Context())
            {
                Employee employee = new Employee();
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
