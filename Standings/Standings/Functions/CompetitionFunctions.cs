using Standings.Database;
using Standings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standings.Functions
{
    public class CompetitionFunctions
    {
        public static void Add(string name, string location, DateTime date, Level level)
        {
            using (Context context = new Context())
            {
                Competition c = new Competition();
                c.Name = name;
                c.Location = location;
                c.Date = date;
                c.Level = level;
                context.Competitions.Add(c);
                context.SaveChanges();
            }
        }
        public void Delete(int Id)
        {
            using (Context db = Connection.Connect())
            {
                Competition c = db.Competitions
                    .Where(q => q.Id == Id)
                    .FirstOrDefault();

                db.Competitions.Remove(c);
                db.SaveChanges();
            }
        }

        public static void Edit(string Name, string Location, DateTime date, Level level, int Id)
        {
            using (Context context = new Context())
            {
                using (Context db = new Context())
                {
                    Competition c = db.Competitions
                    .Where(q => q.Id == Id)
                    .FirstOrDefault();
                    c.Name = Name;
                    c.Date = date;
                    c.Location = Location;
                    c.Level = level;
                    db.SaveChanges();
                }
            }
        }
    }
}
