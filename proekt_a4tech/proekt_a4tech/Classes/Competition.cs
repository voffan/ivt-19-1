﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proekt_a4tech
{
    public enum Level
    {
        Urban,
        District,
        Regional,
        State,
        World_Continental,
        Olympic
    }
    public enum Location
    {

    }
    public class Competition
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public Location Location { get; set; }
        public Level Level { get; set; }
        public virtual List<Judge> Judges { get; set; }
    }
}
