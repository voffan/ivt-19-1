using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Models
{
    class Order
    {
        public int Id { get; }
        public DateTime Order_date { get; set; }
        public DateTime Return_date { get; set; }
        public int Cost { get; set; }
        public OrderStatus Status { get; set; }
        public Deposit OrderDeposit { get; set; }
        public List<Disk> Disks { get; set; }
    }
}
