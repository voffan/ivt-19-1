using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    public class Film
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Название")]
        [MaxLength(200)]
        public string Name { get; set; }

        [DisplayName("Страна")]
        public virtual Country FilmCounty { get; set; }

        [DisplayName("Студия")]
        public virtual Studio FilmStudio { get; set; }

        [DisplayName("Режиссёр")]
        public virtual Person FilmDirector { get; set; }

        [DisplayName("Жанры")]
        public virtual List<Genre> Genres { get; set; }

        [DisplayName("Диски")]
        public virtual List<Disk> Disks { get; set; }
    }
}