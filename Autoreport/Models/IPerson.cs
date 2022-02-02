using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Models
{
    interface IPerson
    {
        public int Id { get; }
        public string First_name { get; set; }
        public string Second_name { get; set; }
    }
}
