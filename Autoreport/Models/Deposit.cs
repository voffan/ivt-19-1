using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Models
{
    enum DepositType
    {
        Money,
        Document
    }

    class Deposit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DepositType Type { get; set; }
    }
}
