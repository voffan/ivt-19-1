using Standings.Database;
using Standings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Standings.Functions
{
    public class JudgeFunctions
    {
        private Judge currentJudge;
        public void Delete()
        {

        }

        public void Edit()
        {

        }
        public void Login(string login, string pwd)
        {
            using (Context db = Connection.Connect())
            {
                Judge empl = db.Judges.Where(p => p.Login == login).FirstOrDefault();

                if (empl == null)
                {
                    throw new Errors.UserNotExist("Пользователь с таким логином не найден");
                }

                bool validationResult = empl.Password.CompareTo(pwd)==0;

                if (!validationResult)
                {
                    throw new Errors.IncorrectPassword("Неправильный пароль");
                }

                currentJudge = empl;
            }
        }
    }
}
