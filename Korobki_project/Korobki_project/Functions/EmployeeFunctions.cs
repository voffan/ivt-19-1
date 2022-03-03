using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;

namespace Korobki_project.Functions
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
