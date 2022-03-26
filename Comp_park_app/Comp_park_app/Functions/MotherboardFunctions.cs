using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_park_app.Functions
{
    class MotherboardFunctions
    {
        public void Add(string name, string manufacturer)
        {
            Motherboard motherboard = new Motherboard()
            {
                Name = name,
                Manufacturer = manufacturer,
            };

            using (Context c = new Context())
            {
                //... initiate field
                c.Motherboards.Add(motherboard);
                c.SaveChanges();
            }
        }

        public void Delete(int index)
        {
            Motherboard motherboard;
            using (Context c = new Context())
            {
                motherboard = c.Motherboards.Find(index);
                c.Remove(motherboard);
                c.SaveChanges();
            }
        }

        public void Edit(int id, string name, string manufacturer)
        {
            Motherboard motherboard;
            using (Context c = new Context())
            {
                motherboard = c.Motherboards.Find(id);
                motherboard.Name = name;
                motherboard.Manufacturer = manufacturer;

                c.SaveChanges();
            }
        }
    }
}
