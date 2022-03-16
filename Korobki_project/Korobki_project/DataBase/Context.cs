using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Korobki_project.Classes;

namespace Korobki_project
{
    public class Context : DbContext
    {
        //public Context() : base("MyStri") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Typee> Typees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=korobkibd;user=root;password=root;");
        }
    }
}
