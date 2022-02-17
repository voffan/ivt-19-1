using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Autoreport.Services;

namespace Autoreport.Database
{
    public static class Connection
    {
        private static DataContext _context;

        public static DataContext Context
        {
            get => _context;
        }

        public static ClientService _clientService = new ClientService();
        public static DepositService _depositService = new DepositService();
        public static DiskService _diskService = new DiskService();
        public static EmployeerService _employeerService = new EmployeerService();
        public static FilmService _filmService = new FilmService();
        public static OrderService _orderService = new OrderService();

        public static void Connect()
        {
            _context = new DataContext();

            if (!_context.Database.CanConnect())
            {
                throw new Errors.DbConnectionError("Couldn't connect to database");
            }
        }
    }
}
