using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    public class Person
    {
        [Key] // нужно для ForeignKey моделей, ссылающихся на эту или производные
        public int Id { get; set; }

        [Required, DisplayName("Имя"), MaxLength(100), MinLength(1)]
        public string First_name { get; set; }

        [Required, DisplayName("Фамилия"), MaxLength(100), MinLength(1)]
        public string Last_name { get; set; }

        [DisplayName("Отчество"), MaxLength(100)]
        public string Middle_name { get; set; }

        public virtual List<Film> Films { get; set; }

        public override string ToString()
        {
            if (Middle_name.Length > 0)
                return String.Format("{0} {1}.{2}.", Last_name, First_name[0], Middle_name[0]);
            else
                return String.Format("{0} {1}.", Last_name, First_name[0]);
        }
    }
}
