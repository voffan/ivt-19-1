using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    public class Film
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        [MaxLength(200)]
        public string Name { get; set; }

        [DisplayName("Год")]
        public DateTime Year { get; set; }

        [DisplayName("Страна")]
        public virtual Country Film_Country { get; set; }

        [DisplayName("Режиссёр")]
        public virtual Person Film_Director { get; set; }

        public virtual List<Genre> Genres { get; set; }
        public virtual List<Disk> Disks { get; set; }
    }
}