using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using gallerys.Models;

namespace gallerys.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public DateTime Oper_date { get; set; }
        public int PaintingId { get; set; }
        public virtual Painting Painting { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        
        public int ToId { get; set; }
        [ForeignKey("ToId")]
        public Place To { get; set; }

        public int FromId { get; set; }
        [ForeignKey("FromId")]
        public Place From { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
