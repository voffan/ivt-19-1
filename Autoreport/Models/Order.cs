using Autoreport.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autoreport.Models
{
    [TypeConverter(typeof(ExpectationResultConverter<OrderStatus>))]
    public enum OrderStatus
    {
        [Description("В процессе")]
        Proceed = 0,
        [Description("Просрочен")]
        Expired = 1,
        [Description("Завершен")]
        Completed = 2
    }

    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required, DisplayName("Стоимость"), Range(1.0, 100000.0)]
        public double Cost { get; set; }

        [Required, DisplayName("Дата заказа"), Column(TypeName = "Date")]
        public DateTime Order_date { get; set; }

        [Required, DisplayName("Дата возврата"), Column(TypeName = "Date")]
        public DateTime Return_date { get; set; }

        [Required, DisplayName("Статус")]
        public OrderStatus Status { get; set; }

        [Required, DisplayName("Клиент")]
        public virtual Client OrderClient { get; set; }

        [ForeignKey("OrderClient")]
        public int ClientId { get; set; }

        [Required, DisplayName("Сотрудник")]
        public virtual Employee OrderEmployee { get; set; }

        [ForeignKey("OrderEmployee")]
        public int EmployeeId { get; set; }

        [DisplayName("Залог")]
        public virtual Deposit? OrderDeposit { get; set; }

        [ForeignKey("OrderDeposit")]
        public int? DepositId { get; set; }

        [Required, DisplayName("Диски")]
        public virtual List<Disk> Disks { get; set; }

        public override string ToString()
        {
            string status = TypeDescriptor.GetConverter(Status).ConvertToString(Status);
            return $"({status}){Cost}р. От: {Order_date.ToString("dd/MM/yyyy")} До: {Return_date.ToString("dd/MM/yyyy")}";
        }
    }
}
