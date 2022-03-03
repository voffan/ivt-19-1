using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;

namespace Korobki_project.Functions
{
    class ShiftFunctions
    {
        public void Add()
        {
            using (Context c = new Context())
            {
                Shift shift = new Shift();
                //... initiate field
                c.Shifts.Add(shift);
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
