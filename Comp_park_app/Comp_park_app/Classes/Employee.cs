using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Comp_park_app
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        public virtual List<Computer> Computers { get; set; }
        public virtual List<Peripheral> Peripherals { get; set; }
    }
}
