using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project.Classes
{

    public class Plan
    {
        public int Id { get; set; }
        public int count_box { get; set; }
        [MaxLength(20)]
        public string planDate { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
