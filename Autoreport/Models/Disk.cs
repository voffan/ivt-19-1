using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Models
{
    class Disk
    {
        public int Id { get; set; }
        public int General_count { get; set; }
        public int Current_count { get; set; }
        public int Cost { get; set; }
        public virtual List<Film> Films { get; set; }
    }
}
