using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Comp_park_app {
    public class Position {

        [DisplayName("Номер")]
        public int Id { get; set; }

        [DisplayName("Название"), MaxLength(100)]
        public string Name { get; set; }

        public override string ToString() {
            return Name;
        }
    }
}
