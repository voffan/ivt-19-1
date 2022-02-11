using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using gallerys.Models;

namespace gallerys.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public enum Right { SYSadmin, director, manager, restorer }
        public int PositionId { get; set; }
        public virtual Position Positions { get; set; }
        public virtual List<Journal> Journals { get; set; }
    }
}
