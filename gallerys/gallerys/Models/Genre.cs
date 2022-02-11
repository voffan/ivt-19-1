using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using gallerys.Models;

namespace gallerys.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual List<Painting> Paintings { get; set; }
    }
}
