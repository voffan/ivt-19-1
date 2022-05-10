using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Comp_park_app {
    public enum Status {
        Working,
        InRepair,
        Removed
    }

    public class Peripheral {

        [DisplayName("Номер")]
        public int Id { get; set; }

        [DisplayName("Наименование"), MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Инвентарный номер"), MaxLength(100)]
        public string ItemNo { get; set; }

        [DisplayName("Статус")]
        public Status Status { get; set; }

        [DisplayName("Дата"), Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [DisplayName("Причина")]
        public string Reason { get; set; }

        [DisplayName("Номер отдела")]
        public int DepartmentId { get; set; }

        [DisplayName("Отдел")]
        public virtual Department Department { get; set; }

        [DisplayName("Номер сотрудника")]
        public int EmployeeId { get; set; }

        [DisplayName("Сотрудник")]
        public virtual Employee Employee { get; set; }

    }
}
