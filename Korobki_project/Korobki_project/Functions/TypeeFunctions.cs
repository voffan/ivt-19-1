using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;
using Microsoft.EntityFrameworkCore;

namespace Korobki_project.Functions
{
   public class TypeeFunctions
    {
        public void Add(string type_name)
        {
            Typee typee = new Typee()
            {
                Type_name = type_name,
            };
            using (Context c = new Context())
            {

                c.Typees.Add(typee);
                c.SaveChanges();
            }
        }

        public void Delete(int index)
        {
            Typee table;
            using (Context c = new Context())
            {
                table = c.Typees.Find(index);
                c.Remove(table);
                c.SaveChanges();
            }
        }

        public void Edit(int id, string type_name)
        {
            Typee typee;
            using (Context c = new Context())
            {
                typee = c.Typees.Find(id);
                typee.Type_name = type_name;
                c.Entry(typee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();

            }
        }
        public static List<Typee> Search(string name)
        {
            using (Context c = new Context())
            {

                var search = c.Typees
                    .Where(b => b.Type_name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
