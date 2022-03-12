using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    public class Person
    {
        public int Id { get; set; }

        [DisplayName("Имя"), MaxLength(100)]
        public string First_name { get; set; }

        [DisplayName("Фамилия"), MaxLength(100)]
        public string Last_name { get; set; }

        [DisplayName("Отчество"), MaxLength(100)]
        public string Middle_name { get; set; }

        public override string ToString()
        {
            return String.Format("Id: {0}, Name: {1}", Id, First_name);
        }
    }
}
