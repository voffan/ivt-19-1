using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_park_app.Functions
{
    class ComputerFunctions
    {
        public void Add()
        {
            using (Context c = new Context())
            {
                Computer computer = new Computer();
                //... initiate field
                c.Computers.Add(computer);
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
