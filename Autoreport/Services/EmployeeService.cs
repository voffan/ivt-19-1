using System;
using System.Collections.Generic;
using System.Text;
using Autoreport.Models;
using Autoreport.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
                Employee empl = db.Employees.Where(p => p.Id >= 0).FirstOrDefault();

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
                Employee empl = db.Employees.Where(p => p.Login == login).FirstOrDefault();

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

        public void Add(string lastName, string firstName, string middleName, 
                        string passport, Position position, string phone,
                        string login, string password)
        {
            using (DataContext db = Connection.Connect())
            {
                if (db.Employees.Where(empl => empl.Login == login).Count() > 0)
                {
                    throw new Errors.UserAlreadyExists("Пользователь с таким логином уже существует");
                }
            }

            string[] passportSplited = passport.Split("-");
            int passportSerial, passportNumber;

            Int32.TryParse(passportSplited[0], out passportSerial);
            Int32.TryParse(passportSplited[1], out passportNumber);

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
        }

        public List<Employee> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Employees.ToList();
            }
        }
        public Employee GetById(int empl_id)
        {
            using (DataContext db = Connection.Connect())
            {
                Employee empl = db.Employees
                    .Where(empl => empl.Id == empl_id).ToList()[0];
                return empl;
            }
        }
        public void Get()
        {

        }

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Employees.Remove(db.Employees.Where(empl => empl.Id == Id).ToList()[0]);
                db.SaveChanges();
            }
        }

        public void Edit(Employee editingEntity, string lastName, string firstName, string middleName,
                        string passport, Position position, string phone,
                        string login)
        {
            using (DataContext db = Connection.Connect())
            {

                var empl = db.Employees
                    .First(x => x.Id == editingEntity.Id);

                string[] passportSplited = passport.Split("-");
                int passportSerial, passportNumber;

                Int32.TryParse(passportSplited[0], out passportSerial);
                Int32.TryParse(passportSplited[1], out passportNumber);

                empl.Last_name = lastName;
                empl.First_name = firstName;
                empl.Middle_name = middleName;
                empl.Passport_number =passportNumber;
                empl.Passport_serial =passportSerial;
                empl.EmplPosition = position;
                empl.Phone_number = phone;
                empl.Login = login;
                db.SaveChanges();
            }
        }
    }
}
