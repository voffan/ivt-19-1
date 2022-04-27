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
        public void Add(string name, int date, int price, status stat, int author, int genre)
        {
            Painting paint = new Painting() { Name = name, Year = date, Price = price, Status = stat, AuthorId = author, GenreId = genre };
            using (gallContext db = Connection.Connect())
            {
                db.Paintings.Add(paint);
                db.SaveChanges();
            }
        }
        public void Edit(string name, int date, int price, status stat, int author, int genre)
        {
            Painting paint = new Painting() { Name = name, Year = date, Price = price, Status = stat, AuthorId = author, GenreId = genre };
            using (gallContext db = Connection.Connect())
            {
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
    }
}
