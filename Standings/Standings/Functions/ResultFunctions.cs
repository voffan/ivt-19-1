using Standings.Database;
using Standings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standings.Functions
{
    public class ResultFunctions
    {
        public static void Add(Sportsman sportsman, Category category, Competition competition, SportKind sportKind, string record)
        {
            using (Context context = new Context())
            {
                Competition comp = context.Competitions.Find(competition.Id);
                Result c = new Result();
                c.SportsmanId = sportsman.Id;
                c.Competitions.Add(comp);
                c.SportKindId = sportKind.Id;
                c.CategorynId = category.Id;
                c.Record = record;
                context.Results.Add(c);
                context.SaveChanges();
            }
        }
        public void Delete(int Id)
        {
            using (Context db = Connection.Connect())
            {
                Result c = db.Results
                    .Where(q => q.Id == Id)
                    .FirstOrDefault();

                db.Results.Remove(c);
                db.SaveChanges();
            }
        }


        public static void Edit(Sportsman sportsman, SportKind kind, Category category, string record, Competition competition, int id)
        {
            using (Context context = new Context())
            {
                using (Context db = new Context())
                {
                    Result c = db.Results
                    .Where(q => q.Id == id)
                    .FirstOrDefault();
                    c.SportsmanId = sportsman.Id;
                    c.SportKindId = kind.Id;
                    c.CategorynId = category.Id;

                    c.Record = record;
                    db.SaveChanges();
                }
            }
        }
    }
}
