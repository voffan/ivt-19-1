using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Autoreport.Services;

namespace Autoreport.Database
{
    public static class Connection
    {
        public static readonly ClientService clientService = new ClientService();
        public static readonly DepositService depositService = new DepositService();
        public static readonly DiskService diskService = new DiskService();
        public static readonly EmployeeService employeeService = new EmployeeService();
        public static readonly FilmService filmService = new FilmService();
        public static readonly OrderService orderService = new OrderService();
        public static readonly HashService hashService = new HashService();

        public static DataContext Connect()
        {
            DataContext context = new DataContext();

            if (!context.Database.CanConnect())
            {
                throw new Errors.DbConnectionError("Couldn't connect to database");
            }

            return context;
        }
    }
}
