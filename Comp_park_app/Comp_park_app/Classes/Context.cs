using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using Comp_park_app.Classes;

namespace Comp_park_app.Classes
{
    public class Context : DbContext
    {
        public Context() : base("MyString") { }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HDD> HDDs { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Peripheral> Peripherals { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<RAM> RAMs { get; set; }
    }
}
