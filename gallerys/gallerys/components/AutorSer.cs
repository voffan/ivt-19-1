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
        public void Add(string name, string bio)
        {
            Author author = new Author() { Name = name, Bio = bio };

            using (gallContext db = Connection.Connect())
            {
                db.Authors.Add(author);
                db.SaveChanges();
            }
        }
        public void Edit(int id, string name, string bio)
        {
            Author au = new Author();
            using (gallContext db = Connection.Connect())
            {
                au = db.Authors.Find(id);
                au.Name = name;
                au.Bio = bio;
                db.Entry(au).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public int ReturnId(TextBox t1)
        {
            string str = t1.Text;
            using (gallContext db = Connection.Connect())
            {
                Author author = db.Authors.Where(p => p.Name == str).FirstOrDefault();

                if (author == null)
                {
                    throw new Errors.UserErrors("Ошибка возвращения идентификатора автора");
                }
                return author.Id;
            }
        }
    }
}
