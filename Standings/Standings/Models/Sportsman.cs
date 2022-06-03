using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Standings.Models
{
    public enum StatusSport
    {
        Inactive,
        Active
    }
    public enum Sex
    {
        Мужчина,
        Женщина
    }
    public class Sportsman
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }

        [Range(0, 300)]
        public float Weight { get; set; }
        public bool Disability { get; set; }

        public int NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }

        public StatusSport StatusSport { get; set; }
        public Sex Sex { get; set; }
        public override string ToString()
        {
            return FullName;
        }
    }
}
