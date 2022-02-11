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
<<<<<<< HEAD
<<<<<<< HEAD
        public string Name { get; set; }

=======
        public string name { get; set; }
>>>>>>> 7201d5404ef0aa40d2c13fbb96afa413e15e118e
=======
        public string name { get; set; }
>>>>>>> 7201d5404ef0aa40d2c13fbb96afa413e15e118e
    }
}
