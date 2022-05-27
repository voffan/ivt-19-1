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

    class DateExpired : Exception
    {
        public DateExpired(string message) : base(message) { }
    }

    class DateNotExpired : Exception
    {
        public DateNotExpired(string message) : base(message) { }
    }

    class LowDeposit : Exception
    {
        public LowDeposit(string message) : base(message) { }
    }

    class IncorrectReturnDate : Exception
    {
        public IncorrectReturnDate(string message) : base(message) { }
    }
}
