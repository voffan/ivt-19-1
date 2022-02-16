using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    class Disk : Model
    {
        public int Id { get; set; }
        [Range(0, 100000)]
        public int General_count { get; set; }
        [Range(0, 100000)]
        public int Current_count { get; set; }
        [Range(0.1, 10000.0)]
        public double Cost { get; set; }
        public string Article { get; set; }

        public virtual List<Film> Films { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
