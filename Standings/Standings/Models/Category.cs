using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Standings.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public int SportKindId { get; set; }
        public virtual SportKind SportKind { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
