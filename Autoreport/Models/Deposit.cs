using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    public enum DepositType
    {
        Money = 0,
        Document = 1,
        MoneyAndDocument = 2
    }

    class Deposit : Model
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [Range(1.0, 100000.0)]
        public string Value { get; set; }
        public DepositType Type { get; set; }
    }
}
