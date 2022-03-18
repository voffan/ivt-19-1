using System;
using System.Collections.Generic;
using System.Text;
using Autoreport.Models;
using Autoreport.Database;
using Autoreport.UI.Classes;
using System.Linq;
using System.Windows.Forms;

namespace Autoreport.Services
{
    public class DiskService
    {
        public void Add(string article, string _count, string _cost, List<Film> films)
        {
            int count = Int32.Parse(_count);
            int cost = Int32.Parse(_cost);

            Disk disk = new Disk()
            {
                Article = article,
                General_count = count,
                Cost = cost,
                Films = films
            };

            using (DataContext db = Connection.Connect())
            {
                db.Update(disk);
                db.Disks.Add(disk);
                db.SaveChanges();
            }
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

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Disks.Remove(db.Disks.Where(empl => empl.Id == Id).ToList()[0]);
                db.SaveChanges();
            }
        }

        public void Edit()
        {

        }
    }
}
