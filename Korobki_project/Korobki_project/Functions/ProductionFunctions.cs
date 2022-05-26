using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;
using Microsoft.EntityFrameworkCore;

namespace Korobki_project.Functions
{
    class ProductionFunctions
    {
        public void Add(int teamid, int productid,int count,string comment)
        {
            Production production = new Production()
            {
                TeamId=teamid,
                ProductId=productid,
                Count=count,
                Comment=comment,
            };
            using (Context c = new Context())
            {

                c.Productions.Add(production);
                c.SaveChanges();
            }
        }
        public void Delete(int index)
        {
            Production table;
            using (Context c = new Context())
            {
                table = c.Productions.Find(index);
                c.Remove(table);
                c.SaveChanges();
            }
        }
        public void Edit(int id, int teamid, int productid, int count,string comment)
        {
            Production production;
            using (Context c = new Context())
            {
                production = c.Productions.Find(id);
                production.TeamId = teamid;
                production.ProductId = productid;
                production.Count = count;
                production.Comment = comment;
                c.Entry(production).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();

            }
        }
        public static List<Production> Search(string date)
        {
            using (Context c = new Context())
            {

                var search = c.Productions.Include("Team").Include("Product")
                    .Where(b => b.Team.Date.ToString().Contains(date))
                    .ToList();
                return search;
            }
        }
    }
}
