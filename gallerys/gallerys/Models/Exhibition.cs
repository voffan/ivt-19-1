using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using gallerys.Models;

namespace gallerys.Models
{
    public class Exhibition
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Place { get; set; }
    }
}
