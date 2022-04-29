using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;

namespace Korobki_project.Functions
{
    class TypeeFunctions
    {
        public void Add()
        {
            using (Context c = new Context())
            {
                Typee Typee = new Typee();
                //... initiate field
                c.Typees.Add(Typee);
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
    }
}
