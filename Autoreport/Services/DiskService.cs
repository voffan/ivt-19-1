using System;
using System.Collections.Generic;
using System.Text;
using Autoreport.Models;
using Autoreport.Database;
using System.Linq;

namespace Autoreport.Services
{
    public class DiskService
    {
        public void Add()
        {

        }

        public void Get()
        {

        }

        public List<Disk> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Disks.ToList();
            }
        }

        public void Delete()
        {

        }

        public void Edit()
        {

        }
    }
}
