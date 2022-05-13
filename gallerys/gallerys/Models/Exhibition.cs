using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using gallerys.Models;

namespace gallerys.Models
{
    public class Exhibition : Place
    {
        [MaxLength(200)]
        public string Place { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
