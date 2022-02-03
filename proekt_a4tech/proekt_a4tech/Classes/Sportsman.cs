﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proekt_a4tech.Classes
{
    public class Sportsman
{
        [Key]
        public int Id{get;set;}
        [MaxLength(200)]
        public string FullNname{get;set;}
        public DateTime Birthday{get; set;}
        public int Sex{get; set;}
        [Range(0,300)]
        public float Weight { get; set; }
        public string Nationality{ get; set;}
        public bool Disability {get; set;}

        public int ResultID{get; set;}
        public Result Result{get; set;}

    }
}
