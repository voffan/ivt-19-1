using Standings.Database;
using Standings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standings.Functions
{
    public class ResultFunctions
    {
        public void Add()
        {
            using (Context context = new Context())
            {
                Result c = new Result();
                //... initiate fields
                context.Results.Add(c);
                context.SaveChanges();
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
