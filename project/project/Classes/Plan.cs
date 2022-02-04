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
        public int Count_box { get; set; }
        public DateTime PlanDate { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
