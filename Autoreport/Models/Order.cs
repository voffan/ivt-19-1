using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Models
{
    enum OrderStatus
    {
        Proceed,
        Expired,
        Completed
    }

    class Order
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public DateTime Order_date { get; set; }
        public DateTime Return_date { get; set; }
        public virtual Client OrderClient { get; set; }
        public virtual Employeer OrderEmployeer { get; set; }
        public OrderStatus Status { get; set; }
        public virtual Deposit OrderDeposit { get; set; }
        public virtual List<Disk> Disks { get; set; }
    }
}
