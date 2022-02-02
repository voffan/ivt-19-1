using System.Data.Entity;

namespace Autoreport.DB.Context
{
    class DepositContext : DbContext
    {
        public DepositContext() : base("connection") { }
        public DbSet<Deposit> Deposits { get; set; }
    }
}
