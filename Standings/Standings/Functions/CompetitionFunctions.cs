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
        public void Add()
        {
            using (Context context = new Context())
            {
                Competition c = new Competition();
                //... initiate fields
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

        public void Edit()
        {

        }
    }
}
