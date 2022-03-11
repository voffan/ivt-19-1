using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gallerys;
using gallerys.Context;
namespace gallerys.components
{
    public class Logins
    {
        public void Login(string log, string pass)
        {
            using (gallContext c = Connection.Connect())
            {
                
            }
        }
    }
}
