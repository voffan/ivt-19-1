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
    public class Shift
    {
        public int Id { get; set; }
        [DisplayName("Смена"), MaxLength(100)]
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }
		public override string ToString()
		{
            return Name;
		}
	}
}
