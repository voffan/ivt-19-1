using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    [Index(nameof(Article), IsUnique = true)] // артикль диска должен быть уникальным
    public class Disk
    {
        public int Id { get; set; }

        [DisplayName("Артикль")]
        public string Article { get; set; }

        [DisplayName("Общее количество"), Range(0, 100000)]
        public int General_count { get; set; }

        [DisplayName("Текущее количество"), Range(0, 100000)]
        public int Current_count { get; set; }

        [DisplayName("Цена"), Range(0.1, 10000.0)]
        public double Cost { get; set; }

        [DisplayName("Фильмы")]
        public virtual List<Film> Films { get; set; }

        [DisplayName("Заказы")]
        public virtual List<Order> Orders { get; set; }
    }
}
