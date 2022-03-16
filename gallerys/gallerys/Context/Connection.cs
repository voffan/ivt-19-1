using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using gallerys;
using gallerys.Context;
using gallerys.components;
namespace gallerys.Context
{
    public static class Connection
    {
        public static readonly EmployeeSer employeeSer = new EmployeeSer();
        public static gallContext Connect()
        {
            gallContext context = new gallContext();

            if (!context.Database.CanConnect())
            {
                throw new DbConnectionError("Couldn't connect to database");
            }

            return context;
        }
    }
}
