using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Autoreport.Models.Classes;

namespace Autoreport.Models
{
    class Employeer : Person
    {
        [Range(4,4)]
        public int Passport_serial { get; set; }
        [Range(6, 6)]
        public int Passport_number { get; set; }
        [MaxLength(20)]
        public string Phone_number { get; set; }
    }
}
