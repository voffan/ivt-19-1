using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Models
{
    class Deposit
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DepositType Type { get; set; }
    }
}
