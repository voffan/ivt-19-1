using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Standings.Database;
using Standings.Models;

namespace Standings.Functions
{
    public class User
    {
        private Employee currentEmployee;
        private Judge currentJudge;
        public void Login(string login, string pwd)
        {
            using (Context db = Connection.Connect())
            {
                Employee empl = db.Employees.Where(p => p.Login == login).FirstOrDefault();

                if (empl != null)
                {
                    bool validationResult = empl.Password.CompareTo(pwd) == 0;

                    if (!validationResult)
                    {
                        throw new Errors.IncorrectPassword("Неправильный пароль");
                    }

                    currentEmployee = empl;
                }else 
                {
                    Judge j = db.Judges.Where(p => p.Login == login).FirstOrDefault();
                    if (j != null)
                    {
                        bool validationResult = j.Password.CompareTo(pwd) == 0;

                        if (!validationResult)
                        {
                            throw new Errors.IncorrectPassword("Неправильный пароль");
                        }

                        currentJudge = j;
                    }
                    else
                    {
                        throw new Errors.UserNotExist("Пользователь с таким логином не найден");
                    }
                }
            }
        }
    }
}
