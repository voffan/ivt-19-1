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
        public int count_box { get; set; }
        [max_Length(20)]
    }
}
