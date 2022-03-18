using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Korobki_project.Classes;


namespace Korobki_project.Classes
{
    public class Production
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Count { get; set; }
        [MaxLength(200)]
        public string Comment { get; set; }
    }
}
