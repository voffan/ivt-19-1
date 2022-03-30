using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Autoreport.Models.Classes;

namespace Autoreport.Models
{
    [TypeConverter(typeof(ExpectationResultConverter<DepositType>))]
    public enum DepositType
    {
        [Description("Деньги")]
        Money,
        [Description("Документ")]
        Document,
        [Description("Деньги и документ")]
        MoneyAndDocument
    }

    /// <summary>
    /// Залог
    /// </summary>
    public class Deposit
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Данные"), MaxLength(300)]
        public string Data { get; set; } // наименование / идентификационные данные документа

        [DisplayName("Сумма"), Range(1.0, 100000.0)]
        public int Value { get; set; }

        [Required, DisplayName("Тип залога")]
        public DepositType DepositType { get; set; }

        [Required, DisplayName("Владелец"), ForeignKey("ClientId")]
        public virtual Client Owner { get; set; }

        public override string ToString()
        {
            return this.DepositType switch
            {
                DepositType.Money => String.Format("Деньги: {0}", Value),
                DepositType.Document => String.Format("Документ: {0}", Data),
                DepositType.MoneyAndDocument => String.Format("Деньги: {0}; документ: {1}", Value, Data),
                _ => String.Format("Деньги: {0}", Value),
            };
        }
    }
}