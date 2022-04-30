using System;
using System.Collections.Generic;
using System.Text;
using Autoreport.Models;
using Autoreport.Database;
using Autoreport.UI.Classes;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Autoreport.Services
{
    public class DiskService
    {
        public void Add(string article, string _count, string _cost, List<Film> films)
        {
            int count = Int32.Parse(_count);
            int cost = Int32.Parse(_cost);

            using (DataContext db = Connection.Connect()) {
                Disk disk = new Disk()
                {
                    Article = article,
                    General_count = count,
                    Current_count = count,
                    Cost = cost,
                    Films = db.Films.Where(x => films.Contains(x)).ToList()
                };

                db.Disks.Add(disk);
                db.SaveChanges();
            }
        }

        public Disk Get(int diskId)
        {
            return null;
        }

        public List<Disk> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Disks
                    .Include(x => x.Films)
                    .Include(x => x.Orders)
                    .ToList();
            }
        }

        public List<Disk> Get(List<int> ids)
        {
            using (DataContext db = Connection.Connect())
            {
                IQueryable<Disk> disks = db.Disks
                    .Where(d => ids.Any(item => item == d.Id));

                return disks.ToList();
            }
        }

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Disks.Remove(db.Disks.First(empl => empl.Id == Id));
                db.SaveChanges();
            }
        }

        public void Edit()
        {

        }
    }
}
