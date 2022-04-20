using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Autoreport.Models.Classes;

namespace Autoreport.Models
{
    [TypeConverter(typeof(ExpectationResultConverter<EmplStatus>))]
    public enum EmplStatus {
        [Description("Работает")]
        Working,
        [Description("Уволен")]
        Fired,
        [Description("В отпуске")]
        Vacation,
        [Description("На больничном/в декрете")]
        Sick
    }

    [TypeConverter(typeof(ExpectationResultConverter<Position>))]
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
        [Required, DisplayName("Серия паспорта"), Range(4, 4)]
        public int Passport_serial { get; set; }

        [Required, DisplayName("Номер паспорта"), Range(6, 6)]
        public int Passport_number { get; set; }

        [Required, DisplayName("Номер телефона"), MaxLength(20)]
        public string Phone_number { get; set; }

        [Required, DisplayName("Статус")]
        public EmplStatus EmplStatus { get; set; }
        [Required, DisplayName("Должность")]
        public Position EmplPosition { get; set; }

        [Required, DisplayName("Логин"), MaxLength(64)]
        public string Login { get; set; }
        [Required, DisplayName("Хэш пароля"), MaxLength(256)]
        public string PasswordHash { get; set; }

        [DisplayName("Заказы")]
        public virtual List<Order> Orders { get; set; }
    }
}
