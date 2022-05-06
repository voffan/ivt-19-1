using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gallerys;
using gallerys.Context;
using gallerys.Models;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace gallerys.components
{
    public class ExhiSer
    {
        public void Add(string name)
        {
            Exhibition exhi = new Exhibition() { Name = name };
            using (gallContext db = Connection.Connect())
            {
                db.Exhibitions.Add(exhi);
                db.SaveChanges();
            }
        }
        public void Edit(int id, string name)
        {
            Exhibition e = new Exhibition();
            using (gallContext db = Connection.Connect())
            {
                e = db.Exhibitions.Find(id);
                e.Name = name;
                db.Entry(e).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public int ReturnId(TextBox t1)
        {
            using (gallContext db = Connection.Connect())
            {
                Exhibition empl = db.Exhibitions.Where(p => p.Name == t1.Text).FirstOrDefault();

                if (empl == null)
                {
                    throw new Errors.UserErrors("Ошибка возвращения идентификатора жанра");
                }
                return empl.Id;
            }
        }
        public void Remove(int id)
        {
            using (gallContext db = Connection.Connect())
            {
                db.Exhibitions.Remove(db.Exhibitions.First(p => p.Id == id));
                db.SaveChanges();
            }
        }
        public static List<Exhibition> Search(string name)
        {
            using (gallContext c = new gallContext())
            {
                var search = c.Exhibitions
                    .Where(b => b.Name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
