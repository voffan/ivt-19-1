using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Autoreport.Models;
using System.Configuration;
using System.Diagnostics;

namespace Autoreport.Data
{
    class DataContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employeer> Employeers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Disk> Disks { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Genre> DopositType { get; set; }
        public DbSet<Deposit> Deposits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["AutoReportDB"].ConnectionString);
        }
    }
}
