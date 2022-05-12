using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Korobki_project.Classes;
using System.ComponentModel;


namespace Korobki_project.Classes
{
    public class Plan
    {
        public int Id { get; set; }
        [DisplayName("Количество коробок")]
        public int Count_box { get; set; }
        [DisplayName("Дата плана"), MaxLength(20)]
        public string PlanDate { get; set; }
        public int ProductId { get; set; }
        [DisplayName("Размер коробки")]
        public virtual Product Product { get; set; }

    }
}
