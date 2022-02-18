using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_park_app.Functions
{
    class PeripheralFunctions
    {
        public void Add()
        {
            using (Context c = new Context())
            {
                Peripheral peripheral = new Peripheral();
                //... initiate field
                c.Peripherals.Add(peripheral);
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
