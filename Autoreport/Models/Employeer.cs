using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autoreport.Models
{
    enum EmplStatus {
        Working,
        Fired,
        Vacation,
        Sick
    }

    enum Position // должности
    {
        Admin,
        Cashier
    }

    public class Employeer : Person
    {
        [Range(4,4)]
        public int Passport_serial { get; set; }
        [Range(6, 6)]
        public int Passport_number { get; set; }
        [MaxLength(20)]
        public string Phone_number { get; set; }

        public EmplStatus EmplStatus { get; set; }
        public Position EmplPosition { get; set; }

        [MaxLength(64)]
        public string Login { get; set; }
        [MaxLength(256)]
        public string PasswordHash { get; set; }
    }
}
