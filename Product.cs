using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project.Classes
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Type_box { get; set; }
        [MaxLength(20)]
        public string Size_box { get; set; }
    }
}
