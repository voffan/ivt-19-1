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
        public int ID { get; set; }
        [MaxLength(20)]
        public int Urban { get; set; }
        public int District { get; set; }
        public int Regional { get; set; }
        public int State { get; set; }
        public int World_Continental { get; set; }
        public int Olympic { get; set; }
    }
}
