using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public virtual List<Film> Films { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
