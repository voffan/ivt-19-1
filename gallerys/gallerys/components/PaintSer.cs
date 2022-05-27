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
    public class PaintSer
    {
        public bool proverka(string name)
        {
            using (gallContext db = Connection.Connect())
            {
                Painting p = db.Paintings.Where(p => p.Name == name).FirstOrDefault();

                if (p == null)
                {
                    return true;
                }
                else return false;
            }
        }
        public void Add(string name, int date, int price, status stat, int author, int genre)
        {
            Painting paint = new Painting();
            using (gallContext db = Connection.Connect())
            {
                paint.Name = name;
                paint.Year = date;
                paint.Price = price;
                paint.Status = stat;
                paint.AuthorId = author;
                paint.GenreId = genre;
                db.Paintings.Add(paint);
                db.SaveChanges();
            }
        }
        public void Edit(int id, string name, int date, int price, status stat, int author, int genre)
        {
            Painting paint = new Painting();
            using (gallContext db = Connection.Connect())
            {
                paint = db.Paintings.Find(id);
                paint.Name = name;
                paint.Year = date;
                paint.Price = price;
                paint.Status = stat;
                paint.AuthorId = author;
                paint.GenreId = genre;
                db.Entry(paint).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void comboxAuthor(ComboBox combox)
        {
            gallContext c = new gallContext();
            List<Author> stat = c.Authors.ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            foreach (Author usepurpose in stat)
            {
                dt.Rows.Add(usepurpose.Id, usepurpose.Name);
            }
            combox.ValueMember = dt.Columns[0].ColumnName;
            combox.DisplayMember = dt.Columns[1].ColumnName;
            combox.DataSource = dt;
        }
        public void comboxStatus(ComboBox combox)
        {
            gallContext c = new gallContext();
            combox.DataSource = Enum.GetValues(typeof(status));
        }
        public void comboxGenre(ComboBox combox)
        {
            gallContext c = new gallContext();
            List<Genre> stat = c.Genres.ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            foreach (Genre usepurpose in stat)
            {
                dt.Rows.Add(usepurpose.Id, usepurpose.Name);
            }
            combox.ValueMember = dt.Columns[0].ColumnName;
            combox.DisplayMember = dt.Columns[1].ColumnName;
            combox.DataSource = dt;
        }
        public int ReturnId(TextBox t)
        {
            using (gallContext db = Connection.Connect())
            {
                Painting empl = db.Paintings.Where(p => p.Name == t.Text).FirstOrDefault();

                if (empl == null)
                {
                    throw new Errors.UserErrors("Ошибка возвращения идентификатора картины");
                }
                return empl.Id;
            }
        }
        public void Remove(int id)
        {
            using (gallContext db = Connection.Connect())
            {
                db.Paintings.Remove(db.Paintings.First(p => p.Id == id));
                db.SaveChanges();
            }
        }
        public static List<Painting> Search(string name)
        {
            using (gallContext c = new gallContext())
            {
                var search = c.Paintings
                    .Where(b => b.Name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
