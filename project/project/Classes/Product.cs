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
<<<<<<< HEAD
        [MaxLength(20)]
=======
        public int Id { get; set; }
        [MaxLength(200)]
>>>>>>> 71311286e52617c05a1bafa0e14c164a14df0c93
        public string Type_box { get; set; }
        [MaxLength(20)]
        public string Size_box { get; set; }
    }
}
