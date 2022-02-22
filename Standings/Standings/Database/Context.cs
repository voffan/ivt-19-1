using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Diagnostics;
using Standings.Models;

namespace Standings.Database
{
    public class Context : DbContext
    {
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Nationality> Nationalitys { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<SportKind> SportKinds { get; set; }
        public DbSet<Sportsman> Sportsmans { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=standings;user=root;password=1234;");
        }
    }
}
