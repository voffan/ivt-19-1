using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using gallerys.Models;
using System.Configuration;
using System.Diagnostics;


namespace gallerys.Context
{
    public class gallContext: DbContext
    {

        public DbSet<Place> Places { get; set; }
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["gallerybd"].ConnectionString);
            optionsBuilder.UseMySQL("server=10.14.156.158;database=gallery_bd;user=root;password=1234;");
        }
    }
}
