using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    class Disk
    {
        public int Id { get; set; }

        [Range(0, 100000)]
        public int General_count { get; set; }
        [Range(0, 100000)]
        public int Current_count { get; set; }
        [Range(0.1, 10000.0)]
        public int Cost { get; set; }
        public virtual List<Film> Films { get; set; }
    }
}
