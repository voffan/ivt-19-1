using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using gallerys.Models;

namespace gallerys.Models
{
    public class Author
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Bio { get; set; }
        public virtual List<Painting> Paintings { get; set; }

        public override string ToString()
        {
            return Name;

        }
    }
}
