using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Autoreport.Models.Classes;

namespace Autoreport.Models
{
    [TypeConverter(typeof(ExpectationResultConverter<DepositType>))]
    public enum DepositType
    {
        [Description("Деньги")]
        Money = 0,
        [Description("Документ")]
        Document = 1,
        [Description("Деньги и документ")]
        MoneyAndDocument = 2
    }

    /// <summary>
    /// Залог
    /// </summary>
    public class Deposit
    {
        public int Id { get; set; }

        [DisplayName("Данные"), MaxLength(300)]
        public string Data { get; set; } // наименование / идентификационные данные документа

        [DisplayName("Сумма"), Range(1.0, 100000.0)]
        public string Value { get; set; }

        [DisplayName("Тип залога")]
        public DepositType Type { get; set; }

        [DisplayName("Владелец")]
        public virtual Client Owner { get; set; }
    }
}