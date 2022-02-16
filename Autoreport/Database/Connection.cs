using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Autoreport.Database
{
    class Connection
    {
        private DataContext _context;

        public DataContext Context
        {
            get => _context;
        }

        public Connection()
        {
            _context = new DataContext();
            tryConnection();
        }

        public void tryConnection()
        {
            if (!_context.Database.CanConnect())
            {
                throw new Errors.DbConnectionError("Couldn't connect to database");
            }
        }
    }
}
