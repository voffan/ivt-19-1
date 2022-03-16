using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gallerys;
using gallerys.Context;
using gallerys.Models;

namespace gallerys.components.Errors
{
    public class UserErrors:Exception
    {
        public UserErrors(string message) : base(message) { }
    }
    class IncorrectPass:Exception
    {
        public IncorrectPass(string message) : base(message) { }
    }
}
