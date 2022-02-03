using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Models
{
    class Employeer : Person
    {
        public int Password_serial { get; set; }
        public int Password_number { get; set; }
        public string Phone_number { get; set; }
    }
}
