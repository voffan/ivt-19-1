﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Korobki_project.Classes;
using System.ComponentModel;


namespace Korobki_project.Classes
{
    public class Typee
    {
        public int Id { get; set; }
        [DisplayName("Название вида"), MaxLength(20)]
        public string Type_name { get; set; }
        public override string ToString()
        {
            return Type_name;
        }
    }
}
