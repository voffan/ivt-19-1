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

        [DisplayName("Данные документа"), MaxLength(300)]
        public string DocumentData { get; set; }

        [DisplayName("Денежная сумма"), Range(1, 100000)]
        public uint MoneyValue { get; set; }

        [Required, DisplayName("Тип залога")]
        public DepositType DepositType { get; set; }

        [Required, DisplayName("Владелец"), ForeignKey("ClientId")]
        public virtual Client Owner { get; set; }

        public override string ToString()
        {
            return this.DepositType switch
            {
                DepositType.Money => $"Деньги: {MoneyValue}",
                DepositType.Document => $"Документ: {DocumentData}",
                DepositType.MoneyAndDocument => $"Деньги: {MoneyValue}р.; документ: {DocumentData}",
                _ => $"Деньги: {MoneyValue}р."
            };
        }
    }
}