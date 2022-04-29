using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;

namespace Korobki_project.Functions
{
    class ProductFunctions
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
    }
}
