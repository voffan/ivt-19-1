using System.Data.Entity;
using Autoreport.Models;

namespace Autoreport.Context
{
    class UserContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employeer> Employeers { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Studio> Studios { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Genre> DopositType { get; set; }
        // ...
    }
}
