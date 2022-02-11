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
        public int Id { get; set; }
        public virtual Schedule team { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Count { get; set; }
        [MaxLength(200)]
<<<<<<< HEAD
<<<<<<< HEAD
        public string Comment { get; set; }

=======
        public string comment { get; set; }
>>>>>>> 7201d5404ef0aa40d2c13fbb96afa413e15e118e
=======
        public string comment { get; set; }
>>>>>>> 7201d5404ef0aa40d2c13fbb96afa413e15e118e
    }
}
