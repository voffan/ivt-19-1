using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gallerys.Context
{
    class DbConnectionError : Exception
    {
        public DbConnectionError(string message) : base(message) { }
    }
}
