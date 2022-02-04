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
<<<<<<< HEAD
        [MaxLength(30)]
=======
        public int Id { get; set; }
        [MaxLength(100)]
>>>>>>> 71311286e52617c05a1bafa0e14c164a14df0c93
        public string Name { get; set; }
    }
}
