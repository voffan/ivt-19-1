using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;
using Microsoft.EntityFrameworkCore;

namespace Korobki_project.Functions
{
   public class ProductFunctions
    {
        public void Delete(int index)
        {
            Product table;
            using (Context c = new Context())
            {
                table = c.Products.Find(index);
                c.Remove(table);
                c.SaveChanges();
            }
        }
        public void Edit(int id, int typeeid, string size_box)
        {
            Product product;
            using (Context c = new Context())
            {
                product = c.Products.Find(id);
                product.TypeeId = typeeid;
                product.Size_box = size_box;
                c.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();

            }
        }
        public static List<Product> Search(string name)
        {
            using (Context c = new Context())
            {
                var search = c.Products.Include("Typee")
                   .Where(b => b.Typee.Type_name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
