using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Comp_park_app {
    public class Employee {

        [DisplayName("Номер")]
        public int Id { get; set; }

        [DisplayName("ФИО"), MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Пароль"), MaxLength(256)]
        public string Password { get; set; }

        [DisplayName("Номер отдела")]
        public int DepartmentId { get; set; }

        [DisplayName("Отдел")]
        public virtual Department Department { get; set; }

        [DisplayName("Номер должности")]
        public int PositionId { get; set; }

        [DisplayName("Должность")]
        public virtual Position Position { get; set; }

        public virtual List<Computer> Computers { get; set; }

        public virtual List<Peripheral> Peripherals { get; set; }

        public override string ToString() {
            return Name;
        }
    }
}
