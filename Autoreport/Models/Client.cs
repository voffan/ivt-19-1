using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    class Client : Person
    {
        [MaxLength(20)]
        public string Phone_number1 { get; set;}
        [MaxLength(20)]
        public string Phone_number2 { get; set;}
        [Range(0, 20000)]
        public int Order_count { get; set;}
        [Range(0, 20000)]
        public int Debt_count { get; set;}

        public virtual List<Order> Orders { get; set; }
    }
}
