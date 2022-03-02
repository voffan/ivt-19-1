using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    public enum EmplStatus {
        Working,
        Fired,
        Vacation,
        Sick
    }

    public enum Position // должности
    {
        [Description("Администратор")]
        Admin,
        [Description("Кассир")]
        Cashier
    }

    [Index(nameof(Login), IsUnique = true)] // делаем логин работника уникальным
    public class Employee : Person
    {
        [DisplayName("Серия паспорта")]
        [Range(4,4)]
        public int Passport_serial { get; set; }

        [DisplayName("Номер паспорта")]
        [Range(6, 6)]
        public int Passport_number { get; set; }

        [DisplayName("Номер телефона")]
        [MaxLength(20)]
        public string Phone_number { get; set; }

        [DisplayName("Статус")]
        public EmplStatus EmplStatus { get; set; }
        [DisplayName("Должность")]
        public Position EmplPosition { get; set; }

        [DisplayName("Логин")]
        [MaxLength(64)]
        public string Login { get; set; }
        [DisplayName("Хэш пароля")]
        [MaxLength(256)]
        public string PasswordHash { get; set; }
    }
}
