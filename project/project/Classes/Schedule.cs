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
<<<<<<< HEAD
        public Shift Shift { get; set; }
        public DateTime Date { get; set; }
        public int PlanCount { get; set; }
=======
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public virtual Shift Shift { get; set; }
        [MaxLength(20)]
        public string Date { get; set; }
        public int planCount { get; set; }
>>>>>>> 71311286e52617c05a1bafa0e14c164a14df0c93
    }
}
