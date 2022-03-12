using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    public enum OrderStatus
    {
        Proceed = 0,
        Expired = 1,
        Completed = 2
    }

    public class Order
    {
        public int Id { get; set; }

        [DisplayName("Стоимость"), Range(1.0, 100000.0)]
        public double Cost { get; set; }

        [DisplayName("Дата заказа")]
        public DateTime Order_date { get; set; }

        [DisplayName("Дата возврата")]
        public DateTime Return_date { get; set; }

        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }

        [DisplayName("Клиент")]
        public virtual Client OrderClient { get; set; }

        [DisplayName("Сотрудник")]
        public virtual Employee OrderEmployeer { get; set; }

        [DisplayName("Заказ")]
        public virtual Deposit OrderDeposit { get; set; }

        [DisplayName("Диски")]
        public virtual List<Disk> Disks { get; set; }
    }
}
