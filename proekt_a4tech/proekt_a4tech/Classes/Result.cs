using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proekt_a4tech
{
    public class Result
    {
        public int Id {get; set;}
        [MaxLength(100)]
        public float Record{get; set;}
        public int SportsmanId { get; set; }
        public virtual Sportsman Sportsman { get; set; }
        public virtual List<Competition> Competitions { get; set; }
        public int SportKindId { get; set; }
        public virtual SportKind SportKind { get; set; }
        public int CategorynId { get; set; }
        public virtual Category Category { get; set; }
    }
}
