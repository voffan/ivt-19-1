﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
//using proekt_a4tech.Models;
using System.Configuration;
using System.Diagnostics;


namespace proekt_a4tech.DataBase
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
        public DbSet<Sportsman> Sportsmen { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=a4tech;user=root;password=1234;");
        }
    }

}
