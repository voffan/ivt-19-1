using Standings.Database;
using Standings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standings.Functions
{
    public class EmployeeFunctions
    {
        public void Add()
        {
            using (Context context = new Context())
            {
                Employee c = new Employee();
                //... initiate fields
                context.Employees.Add(c);
                context.SaveChanges();
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
