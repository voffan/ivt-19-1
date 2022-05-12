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
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("Имя"), MaxLength(100)]
        public string Name { get; set; }
        [DisplayName("Логин"), MaxLength(25)]
        public string Login { get; set; }
        [DisplayName("Пароль"), MinLength(5)]
        public string Password { get; set; }
        public int PositionId { get; set; }
        [DisplayName("Должность")]
        public virtual Position Position { get; set; }
        [DisplayName("Номер телефона"), MaxLength(20)]
        public string PhoneNumber { get; set; }
        [DisplayName("Адрес"), MaxLength(50)]
        public string Adress { get; set; }
        public int ShiftId { get; set; }
        [DisplayName("Смена")]
        public virtual Shift Shift { get; set; }
    }
}
