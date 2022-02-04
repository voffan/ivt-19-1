using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace proekt_a4tech.Data
{
    internal class Context
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Competition> Competition { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Judge> Judge { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<SportKind> SportKind { get; set; }
        public DbSet<Sportsman> Sportsman { get; set; }

    }
}
