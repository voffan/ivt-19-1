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
    }
}
