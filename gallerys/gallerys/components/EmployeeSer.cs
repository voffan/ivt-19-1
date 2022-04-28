using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gallerys;
using gallerys.Context;
using gallerys.Models;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
namespace gallerys.components
{
    public class EmployeeSer
    {
        Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
        }
        public void Add(string fio, string login, string password, Right right)
        {
            Employee empl = new Employee() { Name = fio, Login1 = login, Passw1 = password, Right = right};
            using (gallContext db = Connection.Connect())
            {
                db.Employees.Add(empl);
                db.SaveChanges();
            }
        }
        public void Edit(int id, string fio, string login, string password, Right right)
        {
            Employee empl = new Employee();
            using (gallContext db = Connection.Connect())
            {
                empl = db.Employees.Find(id);
                empl.Name = fio;
                empl.Login1 = login;
                empl.Passw1 = password;
                empl.Right = right;
                db.Entry(empl).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Login(string log, string pass)
        {
            using (gallContext db = Connection.Connect())
            {
                Employee empl = db.Employees.Where(p => p.Login1 == log && p.Passw1 == pass).FirstOrDefault();
                
                if (empl == null)
                {
                    throw new Errors.UserErrors("Пользователь с таким логином не найден");
                }
                currentEmployee = empl;
            }
        }
        public void comboboxRight(ComboBox comboBox)
        {
            gallContext c = new gallContext();
            comboBox.DataSource = Enum.GetValues(typeof(Right));
        }
        public int ReturnId(TextBox t)
        {
            using (gallContext db = Connection.Connect())
            {
                Employee empl = db.Employees.Where(p => p.Login1 == t.Text).FirstOrDefault();

                if (empl == null)
                {
                    throw new Errors.UserErrors("Невохможно");
                }
                return empl.Id;
            }
        }
    }
}
