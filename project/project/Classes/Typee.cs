using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project.Classes
{
    public class Typee
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Type_name { get; set; }
    }
}
