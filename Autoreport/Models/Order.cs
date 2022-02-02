using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Models
{
    class Order
    {
        public DateTime Order_date { get; set; }
        public DateTime Return_date { get; set; }
        public int Cost { get; set; }
    }
}
