using System.Data.Entity;
using Autoreport.Models;

namespace Autoreport.Context
{
    class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        // public DbSet<DepositType> DepositTypes
        // public DbSet<Deposit> Deposits
        // ...
    }
}
