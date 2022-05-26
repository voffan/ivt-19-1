using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;
using Microsoft.EntityFrameworkCore;

namespace Korobki_project.Functions
{
   public  class ScheduleFunctions
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
        public void Edit(int id, int shiftid, DateTime date, int plancount)
        {
            Schedule schedule;
            using (Context c = new Context())
            {
                schedule = c.Schedules.Find(id);
                schedule.ShiftId = shiftid;
                schedule.Date = date;
                schedule.PlanCount = plancount;
                c.Entry(schedule).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();

            }
        }
        public static List<Schedule> Search(string name)
        {
            using (Context c = new Context())
            {

                var search = c.Schedules.Include("Shift")
                    .Where(b => b.Shift.Name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
