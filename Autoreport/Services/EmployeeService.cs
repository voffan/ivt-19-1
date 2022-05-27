using System;
using System.Collections.Generic;
using System.Text;
using Autoreport.Models;
using Autoreport.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Autoreport.Services
{
    public class EmployeeService
    {
        Employee currentEmployee;

        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
        }

        public void Init()
        {
            using (DataContext db = Connection.Connect())
            {
                Employee empl = db.Employees.FirstOrDefault(p => p.Id >= 0);

                if (empl == null)
                {
                    string emplPassword = "admin";

                    Employee _empl = new Employee()
                    {
                        Last_name = "Админ",
                        First_name = "Админ",
                        Middle_name = "Админ",
                        Passport_serial = 0000,
                        Passport_number = 000000,
                        EmplPosition = Position.Admin,
                        EmplStatus = EmplStatus.Working,
                        Phone_number = "+7 (000) 000-00-00",
                        Login = "admin",
                        PasswordHash = Connection.hashService.GetPasswordHash(emplPassword)
                };
                    db.Employees.Add(_empl);
                    db.SaveChanges();
                }
            }
        }

        public void Login(string login, string pwd)
        {
            using (DataContext db = Connection.Connect())
            {
                Employee empl = db.Employees.FirstOrDefault(p => p.Login == login);

                if (empl == null)
                {
                    throw new Errors.UserNotExist("Пользователь с таким логином не найден");
                }

                bool validationResult = Connection.hashService.ValidatePasswordHash(
                    pwd, empl.PasswordHash);

                if (!validationResult)
                {
                    throw new Errors.IncorrectPassword("Неправильный пароль");
                }

                currentEmployee = empl;
            }
        }

        public Employee Add(string lastName, string firstName, string middleName, 
                        string passport, Position position, string phone,
                        string login, string password)
        {
            using (DataContext db = Connection.Connect())
            {
                if (db.Employees.Count(empl => empl.Login == login) > 0)
                {
                    throw new Errors.UserAlreadyExists("Пользователь с таким логином уже существует");
                }

                CheckPassword(password);
            }

            int[] passportSplited = passport.Split("-").Select(x => Int32.Parse(x)).ToArray();

            int passportSerial = passportSplited[0],
                passportNumber = passportSplited[1];

            string passwordHash = Connection.hashService.GetPasswordHash(password);

            Employee empl = new Employee() { 
                Last_name = lastName, First_name = firstName,
                Middle_name = middleName, Passport_serial = passportSerial,
                Passport_number = passportNumber, EmplPosition=position,
                EmplStatus = EmplStatus.Working, Phone_number = phone,
                Login = login, PasswordHash = passwordHash
            };

            using (DataContext db = Connection.Connect())
            {
                db.Employees.Add(empl);
                db.SaveChanges();
            }

            return empl;
        }

        public void CheckPassword(string password)
        {
            if (password.Length < 6)
                throw new Errors.ShortPassword("Слишком короткий пароль");

            if (!(password.Any(Char.IsLetter) && password.Any(Char.IsDigit) && password.Any(Char.IsUpper)))
            {
                throw new Errors.IncorrectPassword("Пароль должен состоять из заглавных и строчных латинский букв и цифр");
            }
        }

        public List<Employee> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Employees.ToList();
            }
        }

        public Employee Get(int employeeId)
        {
            using (DataContext db = Connection.Connect())
            {
                Employee empl = db.Employees
                    .FirstOrDefault(empl => empl.Id == employeeId);
                return empl;
            }
        }

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Employees.Remove(db.Employees.First(x => x.Id == Id));
                db.SaveChanges();
            }
        }

        public void Edit(Employee editingEntity, string lastName, string firstName, string middleName,
                        string passport, Position position, string phone,
                        string login, string password)
        {
            using (DataContext db = Connection.Connect())
            {
                var emplWithSameLogin = db.Employees.FirstOrDefault(x => x.Login == login);

                if (emplWithSameLogin != null && emplWithSameLogin.Id != editingEntity.Id)
                {
                    throw new Errors.UserAlreadyExists("Пользователь с таким логином уже существует");
                }

                string passwordHash = null;

                if (password.Length > 0)
                {
                    CheckPassword(password);
                    passwordHash = Connection.hashService.GetPasswordHash(password);
                }

                var empl = db.Employees.First(x => x.Id == editingEntity.Id);

                int[] passportSplited = passport.Split("-").Select(x => Int32.Parse(x)).ToArray();

                int passportSerial = passportSplited[0],
                    passportNumber = passportSplited[1];

                empl.Last_name = lastName;
                empl.First_name = firstName;
                empl.Middle_name = middleName;
                empl.Passport_number = passportNumber;
                empl.Passport_serial = passportSerial;
                empl.EmplPosition = position;
                empl.Phone_number = phone;
                empl.Login = login;
                empl.PasswordHash = passwordHash != null ? passwordHash : empl.PasswordHash;

                db.SaveChanges();
            }
        }
    }
}
