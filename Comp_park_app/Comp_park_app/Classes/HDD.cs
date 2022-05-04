using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comp_park_app
{
    public class HDD
    {
        
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Manufacturer { get; set; }
        public int Capacity { get; set; }
        public int? ComputerId { get; set; }
        
        public virtual Computer Computer { get; set; }
    }
}
