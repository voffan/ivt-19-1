using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    public class Person
    {
        public int Id { get; set; }

        [DisplayName("Имя")]
        [MaxLength(100)]
        public string First_name { get; set; }

        [DisplayName("Фамилия")]
        [MaxLength(100)]
        public string Second_name { get; set; }
    }
}
