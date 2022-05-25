using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp_park_app.Functions {
    public class HDDFunctions {
        public void Add(string name, string manufacturer, int capacity) {
            HDD hdd = new HDD() {
                Name = name,
                Manufacturer = manufacturer,
                Capacity = capacity,
            };

            using (Context c = new Context()) {
                //... initiate field
                c.HDDs.Add(hdd);
                c.SaveChanges();
            }
        }

        public void Delete(int index) {
            HDD hdd;
            using (Context c = new Context()) {
                hdd = c.HDDs.Find(index);
                c.Remove(hdd);
                c.SaveChanges();
            }
        }

        public void Edit(int id, string name, string manufacturer, int capacity) {
            HDD hdd;
            using (Context c = new Context()) {
                hdd = c.HDDs.Find(id);
                hdd.Name = name;
                hdd.Manufacturer = manufacturer;
                hdd.Capacity = capacity;
                c.Entry(hdd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();
            }
        }

        public static List<HDD> Search(string name) {
            using (Context c = new Context()) {
                var search = c.HDDs
                    .Where(b => b.Name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
