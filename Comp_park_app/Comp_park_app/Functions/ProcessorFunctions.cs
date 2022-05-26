﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp_park_app.Functions {
    public class ProcessorFunctions {
        public void Add(string name, string manufacturer, string frequency) {
            Processor processor = new Processor() {
                Name = name,
                Manufacturer = manufacturer,
                Frequency = frequency
            };

            using (Context c = new Context()) {
                //... initiate field
                c.Processors.Add(processor);
                c.SaveChanges();
            }
        }

        public void Delete(int index) {
            Processor processor;
            using (Context c = new Context()) {
                processor = c.Processors.Find(index);
                c.Remove(processor);
                c.SaveChanges();
            }
        }

        public void Edit(int id, string name, string manufacturer, string frequency) {
            Processor processor;
            using (Context c = new Context()) {
                processor = c.Processors.Find(id);
                processor.Name = name;
                processor.Manufacturer = manufacturer;
                processor.Frequency = frequency;

                c.Entry(processor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                c.SaveChanges();
            }
        }

        public static List<Processor> Search(string name) {
            using (Context c = new Context()) {
                var search = c.Processors
                    .Where(b => b.Name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
