using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using gallerys.Models;

namespace gallerys.Models
{
    public class Painting
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(1000, 3000)]
        public int Year { get; set; }
        public int Price { get; set; }
        public int status { get; set; }
        public virtual List<Journal> Journals { get; set; }
        public virtual Author Author { get; set; }
        public virtual List<Genre> Genre { get; set; }
    }
}
