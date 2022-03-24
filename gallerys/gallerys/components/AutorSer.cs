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
    public class AutorSer
    {
        public void Add(string surname, string name, string patronymic, string bio)
        {
            string fio = surname + name + patronymic;
            Author author = new Author() { Name = fio, Bio = bio };

            using (gallContext db = Connection.Connect())
            {
                db.Authors.Add(author);
                db.SaveChanges();
            }
        }
    }
}
