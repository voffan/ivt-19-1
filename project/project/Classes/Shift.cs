using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project.Classes
{
    public class Shift
    {
        [MaxLength(30)]
        public int NameId { get; set; }
        public virtual string Name { get; set; }
    }
}
