using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project.Classes
{
    public class Position
    {
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
