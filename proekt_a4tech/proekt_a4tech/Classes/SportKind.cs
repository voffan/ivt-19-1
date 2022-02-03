using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proekt_a4tech
{
    public class SportKind
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public float Name { get; set; }
    }
}
