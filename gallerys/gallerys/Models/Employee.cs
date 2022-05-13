using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using gallerys.Models;
using System.Reflection;
namespace gallerys.Models
{
    public enum Right
    {
        [Description("Системный администратор")]
        admin,
        [Description("Директор")]
        director,
        [Description("Менеджер")]
        manager,
        [Description("Реставратор")]
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
        [NotMapped]
        public string RightAccess { get
            {
                return DescriptionAttributes<Right>.RetrieveAttributesReverse()[Right.ToString()];
            } 
        }
        public virtual List<Journal> Journals { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
