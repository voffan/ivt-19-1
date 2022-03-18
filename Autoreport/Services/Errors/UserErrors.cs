using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoreport.Services.Errors
{
    class UserNotExist : Exception
    {
        public UserNotExist(string message) : base(message) { }
    }

    class IncorrectPassword : Exception
    {
        public IncorrectPassword(string message) : base(message) { }
    }

    class UserAlreadyExists: Exception
    {
        public UserAlreadyExists(string message) : base(message) { }
    }
}
