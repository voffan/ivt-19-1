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

        public int Id { get; set; }
        [MaxLength(100)]
        public string name { get; set; }

    }
}
