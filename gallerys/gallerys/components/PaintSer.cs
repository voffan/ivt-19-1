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
        public void Add(string name, int date, int price, status stat, Author author, Genre genre)
        {
            Painting paint = new Painting() { Name = name, Year = date, Price = price, Status = stat, Author = author, Genre = genre };
            using (gallContext db = Connection.Connect())
            {
                db.Paintings.Add(paint);
                db.SaveChanges();
            }
        }
    }
}
