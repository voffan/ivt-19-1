using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using gallerys.Models;
using System.Reflection;

namespace gallerys.Models
{
    public enum status {
        [Description("На выставке")]
        InExhibition,
        [Description("На реставрации")]
        InRestoration,
        [Description("В хранилище")]
        InStorage
    }
    public class Painting
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(1000, 3000)]
        public int Year { get; set; }
        public int Price { get; set; }
        public status Status { get; set; }
        [NotMapped]
        public string StatusAccess{get
            {
                return DescriptionAttributes<status>.RetrieveAttributesReverse()[Status.ToString()];
            }
        }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public virtual List<Journal> Journals { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
