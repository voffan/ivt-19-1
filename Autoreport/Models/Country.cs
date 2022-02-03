using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    internal class Country
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
