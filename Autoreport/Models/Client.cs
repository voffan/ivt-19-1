using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    public class Client : Person
    {
        [DisplayName("Номер телефона 1")]
        [MaxLength(20)]
        public string Phone_number1 { get; set;}

        [DisplayName("Номер телефона 2")]
        [MaxLength(20)]
        public string Phone_number2 { get; set;}

        [DisplayName("Количество заказов")]
        [Range(0, 20000)]
        public int Order_count { get; set;}

        [DisplayName("Количество задолженностей")]
        [Range(0, 20000)]
        public int Debt_count { get; set;} // задолженности

        public virtual List<Order> Orders { get; set; }
    }
}
