using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_park_app.Functions
{
    class HDDFunctions
    {
        public void Add()
        {
            using (Context c = new Context())
            {
                HDD hdd = new HDD();
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
