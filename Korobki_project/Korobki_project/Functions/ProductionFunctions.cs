using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;

namespace Korobki_project.Functions
{
    class ProductionFunctions
    {
        public void Delete(int index)
        {
            Production table;
            using (Context c = new Context())
            {
                table = c.Productions.Find(index);
                c.Remove(table);
                c.SaveChanges();
            }
        }
    }
}
