using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    enum OrderStatus
    {
        Proceed = 0,
        Expired = 1,
        Completed = 2
    }

    class Order
    {
        public int Id { get; set; }
        [Range(1.0, 100000.0)]
        public double Cost { get; set; }
        public DateTime Order_date { get; set; }
        public DateTime Return_date { get; set; }
        public OrderStatus Status { get; set; }
        public virtual Client OrderClient { get; set; }
        public virtual Employeer OrderEmployeer { get; set; }
        public virtual Deposit OrderDeposit { get; set; }
        public virtual List<Disk> Disks { get; set; }
    }
}
