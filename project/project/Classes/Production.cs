using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project.Classes
{
    public class Production
    {

        public int Id { get; set; }
        public virtual Schedule team { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int count { get; set; }
        [MaxLength(200)]
        public string comment { get; set; }

    }
}
