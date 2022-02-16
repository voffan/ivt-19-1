using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Database.Errors
{
    class DbConnectionError : Exception
    {
        public DbConnectionError(string message) : base(message) { }
    }
}
