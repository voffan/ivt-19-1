using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project.Classes
{
    public class Production
    {
<<<<<<< HEAD
        public Schedule Team { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Count { get; set; }
        [MaxLength(30)]
        public string Comment { get; set; }
=======
        public int Id { get; set; }
        public virtual Schedule team { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int count { get; set; }
        [MaxLength(200)]
        public string comment { get; set; }
>>>>>>> 71311286e52617c05a1bafa0e14c164a14df0c93
    }
}
