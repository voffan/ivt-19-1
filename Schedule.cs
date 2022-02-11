using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project.Classes
{
    public class Schedule
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public virtual Shift Shift { get; set; }
        [MaxLength(20)]
        public string Date { get; set; }
        public int PlanCount { get; set; }
    }
}
