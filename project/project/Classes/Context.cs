using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using project.Classes;

namespace project
{
    public class Context : DbContext
    {
        public Context() : base("MyString") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Typee> Typees { get; set; }

    }
}
