using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proekt_a4tech
{
    public class Level
    {
        public int Urban { get; set; }
        public int District { get; set; }
        public int Regional { get; set; }
        public int State { get; set; }
        public int World_Continental { get; set; }
        public int Olympic { get; set; }
    }
    public class Competition
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public Level Type { get; set; }
    }
}
