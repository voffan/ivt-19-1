using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Korobki_project.Classes;


namespace Korobki_project.Classes
{
    public class Product
    {
        public int Id { get; set; }
        public int TypeeId { get; set; }
        public virtual Typee Typee { get; set; }
        [MaxLength(20)]
        public string Size_box { get; set; }
        public override string ToString()
        {
            return Size_box;
        }
    }
}
