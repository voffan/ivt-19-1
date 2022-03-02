using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_park_app.Functions
{
    class RAMFunctions
    {
        public void Add(string name, string manufacturer, int capacity)
        {
            RAM ram = new RAM()
            {
                Name = name, Manufacturer = manufacturer, Capacity = capacity
            };

            using (Context c = new Context())
            {
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
