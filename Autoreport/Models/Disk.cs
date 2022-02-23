using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    public class Disk
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Общая стоимость")]
        [Range(0, 100000)]
        public int General_count { get; set; }

        [DisplayName("Текущая стоимость")]
        [Range(0, 100000)]
        public int Current_count { get; set; }

        [DisplayName("Цена")]
        [Range(0.1, 10000.0)]
        public double Cost { get; set; }

        [DisplayName("Категория")]
        public string Article { get; set; }


        [DisplayName("Фильмы")]
        public virtual List<Film> Films { get; set; }

        [DisplayName("Заказы")]
        public virtual List<Order> Orders { get; set; }
    }
}
