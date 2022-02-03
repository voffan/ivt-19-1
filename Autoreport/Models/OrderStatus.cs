using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Models
{
    internal class OrderStatus
    {
        public int Id { get; }
        public string Proceed { get; set; }
        public string Expired { get; set; }
        public int Completed { get; set; }
    }
}
