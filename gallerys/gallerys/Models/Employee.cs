using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using gallerys.Models;

namespace gallerys.Models
{
    public enum Right
    {
        admin,
        director,
        manager,
        restorer
    }
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Login1 { get; set; }
        [MinLength(4)]
        public string Passw1 { get; set; }
        public Right Right { get; set; }
        public int PositionId { get; set; }
        public virtual Position Positions { get; set; }
        public virtual List<Journal> Journals { get; set; }
    }
}
