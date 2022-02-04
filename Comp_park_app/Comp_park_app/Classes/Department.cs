using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Comp_park_app
{
    class Department
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int Number { get; set; }

    }
}
