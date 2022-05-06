using Standings.Database;
using Standings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standings.Functions
{
    public class SportsmanFunctions
    {
        public static void Add(string Name, bool b, double Ves, DateTime Date, Sex Sex, StatusSport StatusSport, Nationality Nation)
        {
            using (Context context = new Context())
            {
                Sportsman c = new Sportsman();
                c.FullNname = Name;
                c.Birthday = Date;
                c.Weight = (float)Ves;
                c.Disability = b;
                c.Sex = Sex;
                c.StatusSport = StatusSport;
                c.NationalityId = Nation.Id;
                context.Sportsmans.Add(c);
                context.SaveChanges();
            }
        }
        public void Delete(int Id)
        {
            using (Context db = Connection.Connect())
            {
                Sportsman c = db.Sportsmans
                    .Where(q => q.Id == Id)
                    .FirstOrDefault();

                db.Sportsmans.Remove(c);
                db.SaveChanges();
            }
        }

        public void Edit()
        {

        }
    }
}
