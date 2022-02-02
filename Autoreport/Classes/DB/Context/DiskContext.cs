using System.Data.Entity;

namespace Autoreport.DB
{
    class DiskContext : DbContext
    {
        public DiskContext() : base("connection") { }
        public DbSet<Disk> Disks { get; set; }
    }
}
