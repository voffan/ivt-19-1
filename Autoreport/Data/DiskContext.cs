using System.Data.Entity;
using Autoreport.Models;

namespace Autoreport.Data
{
    class DiskContext : DbContext
    {
        public DbSet<Disk> Disks { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Genre> Genres { get; set; }
        // ...
    }
}
