using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Comp_park_app {
    public class Computer {

        [DisplayName("Номер")]
        public int Id { get; set; }

        [DisplayName("Номер отдела"), MaxLength(100)]
        public int DepartmentId { get; set; }

        [DisplayName("Отдел")]
        public virtual Department Department { get; set; }

        [DisplayName("Инвентарный номер"), MaxLength(100)]
        public string ItemNo { get; set; }

        [DisplayName("Статус")]
        public Status Status { get; set; }

        [DisplayName("Дата"), Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [DisplayName("Причина")]
        public string Reason { get; set; }

        [DisplayName("Номер сотрудника")]
        public int EmployeeId { get; set; }

        [DisplayName("Сотрудник")]
        public virtual Employee Employee { get; set; }

        public int MotherboardId { get; set; }

        public virtual Motherboard Motherboard { get; set; }

        public virtual List<RAM> RAMs { get; set; }

        public virtual List<Processor> Processors { get; set; }

        public virtual List<HDD> HDDs { get; set; }

    }
}
