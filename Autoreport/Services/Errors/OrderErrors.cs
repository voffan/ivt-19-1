using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoreport.Services.Errors
{
    class NotEnoughDisks : Exception
    {
        public NotEnoughDisks(string message) : base(message) { }
    }
}
