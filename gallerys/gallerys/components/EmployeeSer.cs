using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gallerys;
using gallerys.Context;
using gallerys.Models;
namespace gallerys.components
{
    public class EmployeeSer
    {
        Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
        }
        public void Login(string log, string pass)
        {
            using (gallContext db = Connection.Connect())
            {
                Employee empl = db.Employees.Where(p => p.Login1 == log).FirstOrDefault();
                Employee empp = db.Employees.Where(p => p.Passw1 == pass).FirstOrDefault();
                if (empl == null)
                {
                    throw new Errors.UserErrors("Пользователь с таким логином не найден");
                }
                if (empp == null)
                {
                    throw new Errors.UserErrors("вы ввели неправильный пароль");
                }
            }
        }
    }
}
