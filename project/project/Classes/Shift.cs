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
<<<<<<< HEAD
        [MaxLength(30)]
        public int NameId { get; set; }
        public virtual string Name { get; set; }
=======
        public int Id { get; set; }
        [MaxLength(100)]
        public string name { get; set; }
>>>>>>> 71311286e52617c05a1bafa0e14c164a14df0c93
    }
}
