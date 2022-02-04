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
        public virtual Sportsman ResultSportsman { get; set; }
        public virtual Competition ResultCompetition { get; set; }
        public virtual SportKind ResultSportKind { get; set; }
        public virtual Category ResultCategory { get; set; }
    }
}
