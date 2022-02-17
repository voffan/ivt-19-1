using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using gallerys.Models;
namespace gallerys.Context
{
    public class AppContext: DbContext
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
            optionsBuilder.UseMySQL("server=localhost;database=gallerybd;user=root;password=root");
        }
    }
}
