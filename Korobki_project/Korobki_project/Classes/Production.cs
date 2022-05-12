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
    public class Production
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        [DisplayName("Расписание")]
        public virtual Schedule Team { get; set; }
        public int ProductId { get; set; }
        [DisplayName("Размер Коробки")]
        public virtual Product Product { get; set; }
        [DisplayName("Число")]
        public int Count { get; set; }
        [DisplayName("Комментарий"), MaxLength(200)]
        public string Comment { get; set; }
    }
}
