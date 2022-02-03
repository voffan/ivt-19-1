using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    class Client : Person
    {
        public string Phone_number1 { get; set;}
        public string Phone_number2 { get; set;}
        public int Order_count { get; set;}
        public int Debt_count { get; set;}
    }
}
