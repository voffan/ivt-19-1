using System.Data.Entity;
using Autoreport.Models;

namespace Autoreport.Data
{
    class DiskContext : DbContext
    {
        public DbSet<Disk> Disks { get; set; }
    }
}
