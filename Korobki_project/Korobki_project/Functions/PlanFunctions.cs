using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;
using Microsoft.EntityFrameworkCore;

namespace Korobki_project.Functions
{
   public class PlanFunctions
    {
        public void Add(int count_box,string plandate,int productid)
        {
            Plan plan = new Plan()
            {
                Count_box = count_box,
                PlanDate = plandate,
                ProductId = productid,
            };
            using (Context c = new Context())
            {
               
                c.Plans.Add(plan);
                c.SaveChanges();
            }
        }
        public void Delete(int index)
        {
            Plan table;
            using (Context c = new Context())
            {
                table = c.Plans.Find(index);
                c.Remove(table);
                c.SaveChanges();
            }
        }
        public void Edit(int id, int count_box, string plandDate, int productid)
        {
            Plan plan;
            using (Context c = new Context())
            {
                plan = c.Plans.Find(id);
                plan.Count_box = count_box;
                plan.PlanDate = plandDate;
                plan.ProductId = productid;
                c.Entry(plan).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();

            }
        }

        public static List<Plan> Search(string date)
        {
            using (Context c = new Context())
            {
                var search = c.Plans.Include("Product")
                    .Where(b => b.PlanDate.Contains(date))
                    .ToList();
                return search;
            }
        }
    }
}
