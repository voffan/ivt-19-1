using System;
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
    public class Competition
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public string Location { get; set; }
        public Level Type { get; set; }
        public virtual List<Judge> Judges { get; set; }
    }
}
