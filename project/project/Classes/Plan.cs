using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project.Classes
{
<<<<<<< HEAD
   public class Plan
    {
        public int Count_box { get; set; }
        public DateTime PlanDate { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
=======
    public class Plan
    {
        public int Id { get; set; }
        public int count_box { get; set; }
        [MaxLength(20)]
        public string planDate { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

>>>>>>> 71311286e52617c05a1bafa0e14c164a14df0c93
    }
}
