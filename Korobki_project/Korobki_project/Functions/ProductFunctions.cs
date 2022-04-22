﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;

namespace Korobki_project.Functions
{
    class ProductFunctions
    {
        public void Delete(int index)
        {
            Product table;
            using (Context c = new Context())
            {
                table = c.Products.Find(index);
                c.Remove(table);
                c.SaveChanges();
            }
        }
    }
}
