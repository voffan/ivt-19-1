using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;

namespace Korobki_project.Functions
{
    class TypeeProductions
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

        public void Delete()
        {

        }

        public void Edit()
        {

        }
    }
}
