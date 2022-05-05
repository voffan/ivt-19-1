using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comp_park_app
{
    public class Computer
    {

        public int Id { get; set; }

        [MaxLength(100)]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        [MaxLength(100)]
        public string ItemNo { get; set; }

        public Status Status { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public int MotherboardId { get; set; }

        public virtual Motherboard Motherboard { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual List<RAM> RAMs { get; set; }

        public virtual List<Processor> Processors { get; set; }

        public virtual List<HDD> HDDs { get; set; }

    }
}
