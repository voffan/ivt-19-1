using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_park_app.Functions
{
    class MotherboardFunctions
    {
        public void Add()
        {
            using (Context c = new Context())
            {
                Motherboard motherboard = new Motherboard();
                //... initiate field
                c.Motherboards.Add(motherboard);
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
