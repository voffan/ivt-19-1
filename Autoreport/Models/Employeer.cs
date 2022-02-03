using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Models
{
    class Employeer : IPerson
    {
        public int Id { get; }
        public string First_name { get; set; }
        public string Second_name { get; set; }
        public int Password_serial { get; set; }
        public int Password_number { get; set; }
        public string Phone_number { get; set; }
    }
}
