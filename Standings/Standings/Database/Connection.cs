using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Standings.Functions;

namespace Standings.Database
{
    public static class Connection
    {
        public static readonly CompetitionFunctions competitionFunctions = new CompetitionFunctions();
        public static readonly EmployeeFunctions employeeFunctions = new EmployeeFunctions();
        public static readonly JudgeFunctions judgeFunctions = new JudgeFunctions();
        public static readonly ResultFunctions resultFunctions = new ResultFunctions();
        public static readonly SportsmanFunctions sportsmanFunctions = new SportsmanFunctions();
        public static readonly User user = new User();

        public static Context Connect()
        {

            Context context = new Context();

            if (!context.Database.CanConnect())
            {
                throw new Errors.ConnectionError("Couldn't connect to database");
            }

            return context;
        }
    }
}