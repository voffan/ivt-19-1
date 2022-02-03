using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    class Person
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string First_name { get; set; }
        [MaxLength(100)]
        public string Second_name { get; set; }
    }
}
