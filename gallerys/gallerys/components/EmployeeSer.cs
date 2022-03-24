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
        public void Add(string fio, string login, string password, string right)
        {
            Employee empl = new Employee() { Name = fio, Login1 = login, Passw1 = password };
            if (right == "Директор")
            {
                empl.Right = Right.director;
            }
            if (right == "Реставратор")
            {
                empl.Right = Right.restorer;
            }
            if (right == "Администратор")
            {
                empl.Right = Right.admin;
            }
            if (right == "Менеджер")
            {
                empl.Right = Right.manager;
            }
            using (gallContext db = Connection.Connect())
            {
                db.Employees.Add(empl);
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
            }
        }
    }
}
