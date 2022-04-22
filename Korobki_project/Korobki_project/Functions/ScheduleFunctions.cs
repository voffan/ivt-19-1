using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;

namespace Korobki_project.Functions
{
    class ScheduleFunctions
    {
        public void Delete(int index)
        {
            Schedule table;
            using (Context c = new Context())
            {
                table = c.Schedules.Find(index);
                c.Remove(table);
                c.SaveChanges();
            }
        }
    }
}
