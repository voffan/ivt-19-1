using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comp_park_app
{
    public enum Status { Working, InRepair, Removed}

    public class Peripheral
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string ItemNo { get; set; }

        public Status Status { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
