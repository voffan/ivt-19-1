using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Models
{
    internal class DepositType
    {
        public DepositType(int id, string first_name, string second_name)
        {
            Id = id;
            First_name = first_name;
            Second_name = second_name;
        }
        public int Id { get; }
        public string First_name { get; set; }
        public string Second_name { get; set; }
        public int Money { get; set; }

        public int Document { get; set; }
    }
}
