using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autoreport.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required, DisplayName("Название"), MaxLength(200)]
        public string Name { get; set; }

        [Required, DisplayName("Год выхода"), Range(1900, 2100)]
        public int Year { get; set; }

        [Required, DisplayName("Страна")]
        public virtual Country FilmCountry { get; set; }

        [Required, DisplayName("Режиссеры")]
        public virtual List<Person> FilmDirectors { get; set; }

        [Required, DisplayName("Жанры")]
        public virtual List<Genre> Genres { get; set; }

        public virtual List<Disk> Disks { get; set; }

        public override string ToString()
        {
            return String.Format("{0} ({1})", Name, Year);
        }
    }
}