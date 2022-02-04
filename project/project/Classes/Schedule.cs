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
        public Shift Shift { get; set; }
        public DateTime Date { get; set; }
        public int PlanCount { get; set; }
    }
}
