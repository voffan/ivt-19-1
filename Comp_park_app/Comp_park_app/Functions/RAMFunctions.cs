﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp_park_app.Functions {
    class RAMFunctions {
        public void Add(string name, string manufacturer, int capacity) {
            RAM ram = new RAM() {
                Name = name, Manufacturer = manufacturer, Capacity = capacity
            };

            using (Context c = new Context()) {
                //... initiate field
                c.RAMs.Add(ram);
                c.SaveChanges();
            }
        }

        public void Delete(int index) {
            RAM ram;
            using (Context c = new Context()) {
                ram = c.RAMs.Find(index);
                c.Remove(ram);
                c.SaveChanges();
            }
        }

        public void Edit(int index, string name, string manufacturer, int capacity) {
            RAM ram;
            using(Context c = new Context()) {
                ram = c.RAMs.Find(index);
                ram.Name = name;
                ram.Manufacturer = manufacturer;
                ram.Capacity = capacity;

                c.Entry(ram).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();
            }
        }

        public static List<RAM> Search(string name) {
            using (Context c = new Context()) {
                var search = c.RAMs
                    .Where(b => b.Name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
