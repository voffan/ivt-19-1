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
        public int Id { get; }
        public int Cost { get; set; }
        public DateTime Order_date { get; set; }
        public DateTime Return_date { get; set; }
        public Client OrderClient { get; set; }
        public Employeer OrderEmployeer { get; set; }
        public OrderStatus Status { get; set; }
        public Deposit OrderDeposit { get; set; }
        public List<Disk> Disks { get; set; }

    }
}
