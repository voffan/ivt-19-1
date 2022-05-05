using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Diagnostics;

namespace Comp_park_app
{
    public class Context : DbContext
    {
        //public Context() : base("comp_park") { }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HDD> HDDs { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Peripheral> Peripherals { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"server=localhost;database=autoreport;user=root;password=1234;"
            optionsBuilder.UseMySQL("server=localhost;database=comp_park;user=root;password=1234;");
        }
        

    }
}
