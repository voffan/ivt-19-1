using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Standings.Models
{
    public enum Position
    {
        Manager,
        Admin,
        Trainer,
        Chief,
        Analyst
    }
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Login { get; set; }
        [MaxLength(200)]
        public string Password { get; set; }
        [MaxLength(200)]
        public string FullName { get; set; }
        public Position Position { get; set; }
    }
}
