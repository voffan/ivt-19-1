using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_park_app.Functions
{
    class ProcessorFunctions
    {
        public void Add(string name, string manufacturer, string frequency)
        {
            Processor processor = new Processor()
            {
                Name = name,
                Manufacturer = manufacturer,
                Frequency = frequency
            };

            using (Context c = new Context())
            {
                //... initiate field
                c.Processors.Add(processor);
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
