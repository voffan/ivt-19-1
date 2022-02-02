using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.DB
{
    class Disk
    {
        public int Id { get; }
        public int General_count { get; set; }
        public int Current_count { get; set; }
        public int Cost { get; set; }
    }
}
