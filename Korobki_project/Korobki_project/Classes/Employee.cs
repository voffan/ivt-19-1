using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Korobki_project.Classes;


namespace Korobki_project.Classes
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(25)]
        public string Login { get; set; }
        [MinLength (5)]
        public string Password { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]
        public string Adress { get; set; }
        public int ShiftId { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
