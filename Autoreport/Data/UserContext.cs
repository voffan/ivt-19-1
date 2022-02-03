using System.Data.Entity;
using Autoreport.Models;

namespace Autoreport.Context
{
    class UserContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employeer> Employeers { get; set; }
        // ...
    }
}
