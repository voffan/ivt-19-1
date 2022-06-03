using Standings.Database;
using Standings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standings.Logic
{
    internal class SportsmanLogic
    {
        public static void Add(string Name, bool b, double Ves, DateTime Date, Sex Sex, StatusSport StatusSport, Nationality Nation)
        {
            using(Context c = new Context())
            {
                Sportsman s = c.Sportsmans.Find();

            }
        }
        public static void Edit(string Name, bool b, double Ves, Sex Sex, StatusSport StatusSport, Nationality Nation, int Id)
        {
            using (Context c = new Context())
            {
               // Sportsman s = c.Sportsmans.Find();
                //c.Entry(s).State = System.
                //c.SaveChanges();
            }
        }
        public void Delete(int Id)
        {
            using (Context c = new Context())
            {
                //Sportsman s = c.Sportsmans.Find(id);
               // c.Sportsmans.Remove(s);
               // c.SaveChanges();

            }
        }
    }
}
