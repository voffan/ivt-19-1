using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standings.Database.Errors
{
    class ConnectionError : Exception
    {
        public ConnectionError(string message) : base(message) { }
    }
}
