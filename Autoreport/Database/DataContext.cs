using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Autoreport.Models;
using System.Configuration;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Autoreport.Database
{
    public class DataContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
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
            ServiceCollection serviceCollection = new ServiceCollection();
            IConfigurationRoot configuration = ConfigureServices(serviceCollection);

            optionsBuilder.UseMySQL(configuration["ConnectionStrings:AutoReportDB"]);
        }

        private static IConfigurationRoot ConfigureServices(IServiceCollection serviceCollection)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();
            return configuration;
        }
    }
}
