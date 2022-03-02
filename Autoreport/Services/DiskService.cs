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
        public void Add(string article, string _count, string _cost, ListBox.ObjectCollection items)
        {
            using (DataContext db = Connection.Connect())
            {
                int count = Int32.Parse(_count);
                int cost = Int32.Parse(_cost);

                List<int> films_ids = items.Cast<GridSelectedItem>().Select(item => item.Id).ToList();
                List <Film> films = db.Films.Where(f => films_ids.Any(item => item == f.Id)).ToList();

                Disk disk = new Disk()
                {
                    Article = article,
                    General_count = count,
                    Cost = cost,
                    Films = films
                };

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

        public void Delete()
        {

        }

        public void Edit()
        {

        }
    }
}
