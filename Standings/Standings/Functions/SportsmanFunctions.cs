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
        public void Add()
        {
            using (Context context = new Context())
            {
                Sportsman c = new Sportsman();
                //... initiate fields
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
