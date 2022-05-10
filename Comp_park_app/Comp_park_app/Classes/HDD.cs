using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Comp_park_app {
    public class HDD {

        [DisplayName("Номер")]
        public int Id { get; set; }

        [DisplayName("Название"), MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Производитель"), MaxLength(100)]
        public string Manufacturer { get; set; }

        [DisplayName("Обьем (Гб)")]
        public int Capacity { get; set; }

        [DisplayName("Номер компьютера")]
        public int? ComputerId { get; set; }

        public virtual Computer Computer { get; set; }
    }
}
