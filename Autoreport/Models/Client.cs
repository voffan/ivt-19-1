using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Models
{
    class Client : IPerson
    {
        public int Id { get;}
        public string First_name { get; set; }
        public string Second_name { get; set; }

        public string Phone_number1 { get; set;}
        public string Phone_number2 { get; set;}
        public int Order_count { get; set;}
        public int Debt_count { get; set;}

    }
}
