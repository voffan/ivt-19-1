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
                Classes.Employee employee = new Classes.Employee();
                //... initiate field
                c.Employees.Add(employee);
                c.SaveChanges();
            }
        }

        public void Delete(int index)
        {
            Employee comp;
            using (Context c = new Context())
            {
                comp = c.Employees.Find(index);
                c.Remove(comp);
                c.SaveChanges();
            }
        }
        public void Edit()
        {

        }
    }
}

