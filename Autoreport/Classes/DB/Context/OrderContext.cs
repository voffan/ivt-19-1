using System.Data.Entity;

namespace Autoreport.DB.Context
{
    class OrderContext : DbContext
    {
        public OrderContext() : base("connection") { }
        public DbSet<Order> Orders { get; set; }
    }
}
