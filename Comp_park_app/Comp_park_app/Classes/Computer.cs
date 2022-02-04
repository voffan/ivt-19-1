using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Comp_park_app
{
    class Computer
    {
        public int Id { get; set; }
        public virtual Department Department { get; set; }
        [MaxLength(100)]
        public string ItemNo { get; set; }
        //======
        public int MotherboardId { get; set; }
        public virtual Motherboard Motherboard { get; set; }
        public int ProcessorId { get; set; }
        public virtual Processor Processor { get; set; }
        public int HDDId { get; set; }
        public virtual HDD HDD { get; set; }
        public int RAMId { get; set; }
        public virtual RAM RAM { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
