using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using gallerys.Models;

namespace gallerys.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public DateTime Oper_date { get; set; }
        public int PaintingId { get; set; }
        public virtual Painting Painting { get; set; }
        public virtual List<Employee> Employees { get; set; }

        public int ToId { get; set; }
        [ForeignKey("ToId")]
        public Place To { get; set; }

        public int FromId { get; set; }
        [ForeignKey("FromId")]
        public Place From { get; set; }
    }
}
