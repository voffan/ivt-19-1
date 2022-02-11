using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project.Classes
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public int PhoneNumber { get; set; }
        [MaxLength(50)]
        public string Adress { get; set; }
    }
}
