using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proekt_a4tech
{
    public enum Position
    {
        Manager,
        Admin
    }
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string FullName { get; set; }
        //PositionId
        public Position Position { get; set; }
    }
}
