using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp_park_app.Functions {
    public class MotherboardFunctions {
        public void Add(string name, string manufacturer) {
            Motherboard motherboard = new Motherboard() {
                Name = name,
                Manufacturer = manufacturer,
            };

            using (Context c = new Context()) {
                //... initiate field
                c.Motherboards.Add(motherboard);
                c.SaveChanges();
            }
        }

        public void Delete(int index) {
            Motherboard motherboard;
            using (Context c = new Context()) {
                motherboard = c.Motherboards.Find(index);
                c.Remove(motherboard);
                c.SaveChanges();
            }
        }

        public void Edit(int id, string name, string manufacturer) {
            Motherboard motherboard;
            using (Context c = new Context()) {
                motherboard = c.Motherboards.Find(id);
                motherboard.Name = name;
                motherboard.Manufacturer = manufacturer;

                c.Entry(motherboard).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();
            }
        }

        public static List<Motherboard> Search(string name) {
            using (Context c = new Context()) {
                var search = c.Motherboards
                    .Where(b => b.Name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
