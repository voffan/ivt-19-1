using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    public enum DepositType
    {
        Money = 0,
        Document = 1,
        MoneyAndDocument = 2
    }

    public class Deposit
    {
        public int Id { get; set; }

        [DisplayName("Имя")]
        [MaxLength(200)]
        public string Name { get; set; }

        [DisplayName("Сумма")]
        [Range(1.0, 100000.0)]
        public string Value { get; set; }

        [DisplayName("Тип залога")]
        public DepositType Type { get; set; }
    }
}