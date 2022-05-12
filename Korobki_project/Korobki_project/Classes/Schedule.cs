using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Korobki_project.Classes;
using System.ComponentModel;

namespace Korobki_project.Classes
{
    public class Schedule
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        [DisplayName("Смена")]
        public virtual Shift Shift { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Количество по плану")]
        public int PlanCount { get; set; }
        public override string ToString()
        {
            return Date.ToString("dd.MM.yyyy");
        }
        
        
    }
}
