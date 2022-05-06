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
    public class JanrSer
    {
        public void Add(string name)
        {
            Genre genre = new Genre() { Name = name };
            using (gallContext db = Connection.Connect())
            {
                db.Genres.Add(genre);
                db.SaveChanges();
            }
        }
        public void Edit(int id, string name)
        {
            Genre g = new Genre();
            using (gallContext db = Connection.Connect())
            {
                g = db.Genres.Find(id);
                g.Name = name;
                db.Entry(g).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public int ReturnId(TextBox t1)
        {
            using (gallContext db = Connection.Connect())
            {
                Genre empl = db.Genres.Where(p => p.Name == t1.Text).FirstOrDefault();

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
                db.Genres.Remove(db.Genres.First(p => p.Id == id));
                db.SaveChanges();
            }
        }
        public static List<Genre> Search(string name)
        {
            using (gallContext c = new gallContext())
            {
                var search = c.Genres
                    .Where(b => b.Name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
