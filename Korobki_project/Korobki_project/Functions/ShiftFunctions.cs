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

        public void Delete(int index)
        {
            
                Shift table;
                using (Context c = new Context())
                {
                    table = c.Shifts.Find(index);
                    c.Remove(table);
                    c.SaveChanges();
                }
            
        }

        public void Edit(int id, string name)
        {
            Shift shift;
            using (Context c = new Context())
            {
                shift = c.Shifts.Find(id);
                shift.Name = name;
                c.Entry(shift).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();

            }
        }
    }
}
