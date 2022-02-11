using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Comp_park_app
{
    public class Computer
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [MaxLength(100)]
        public string ItemNo { get; set; }
        public Status Status { get; set; }
        //======
        public int MotherboardId { get; set; }
        public virtual Motherboard Motherboard { get; set; }
        public int ProcessorId { get; set; }
        public virtual Processor Processor { get; set; }
        public int HDDId { get; set; }
        public virtual HDD HDD { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual List<RAM> RAMs { get; set; }
        public virtual List<Processor> Processors { get; set; }
        public virtual List<HDD> HDDs { get; set; }
    }
}
