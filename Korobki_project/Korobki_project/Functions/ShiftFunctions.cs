using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;
using Microsoft.EntityFrameworkCore;

namespace Korobki_project.Functions
{
   public class ShiftFunctions
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
        public static List<Shift> Search(string name)
        {
            using (Context c = new Context())
            {

                var search = c.Shifts
                    .Where(b => b.Name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
