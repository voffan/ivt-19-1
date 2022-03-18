using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Korobki_project.Classes;

namespace Korobki_project.Classes
{
    public class Schedule
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public virtual Shift Shift { get; set; }
        public DateTime Date { get; set; }
        public int PlanCount { get; set; }
       /* public override string ToString()
        {
            return Date.ToString();
        }*/
        
        
    }
}
