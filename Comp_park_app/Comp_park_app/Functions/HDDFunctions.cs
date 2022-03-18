using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_park_app.Functions
{
    class HDDFunctions
    {
        public void Add(string name, string manufacturer, int capacity)
        {
            HDD hdd = new HDD()
            {
                Name = name,
                Manufacturer = manufacturer,
                Capacity = capacity,
            };

            using (Context c = new Context())
            {
                //... initiate field
                c.HDDs.Add(hdd);
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
