using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;

namespace Korobki_project.Functions
{
    class PlanFunctions
    {
        public void Delete(int index)
        {
            Plan table;
            using (Context c = new Context())
            {
                table = c.Plans.Find(index);
                c.Remove(table);
                c.SaveChanges();
            }
        }
    }
}
