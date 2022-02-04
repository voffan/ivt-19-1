using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using gallerys.Models;

namespace gallerys.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public DateTime oper_date { get; set; }
        public virtual List<Painting> Paintings { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
