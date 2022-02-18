using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_park_app.Functions
{
    class RAMFunctions
    {
        public void Add()
        {
            using (Context c = new Context())
            {
                RAM ram = new RAM();
                //... initiate field
                c.RAMs.Add(ram);
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
