using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gallerys;
using gallerys.Context;
using Microsoft.EntityFrameworkCore;
using gallerys.Forms;
using gallerys.Forms.FormsforAdd;
using gallerys.components;
using gallerys.Models;

namespace gallerys.components
{
    public class sortbystring
    {
//        Картины
//   Жанры
//Авторы
//Сотрудники
//Журнал передвижения картин
//Выставки
        public void sorting(string table, string colname, DataGridView dg)
        {
            if (table == "Картины")
            {
                if(colname == "Id")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Paintings.OrderBy(s => s.Id);
                        dg.DataSource = c.Paintings.Include("Author").Include("Genre").ToList();
                        dg.DataSource = p.ToList();
                    }
                }
                if (colname == "Name")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Paintings.OrderBy(s => s.Name);
                        dg.DataSource = c.Paintings.Include("Author").Include("Genre").ToList();
                        dg.DataSource = p.ToList();
                    }
                }
                if (colname == "Price")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Paintings.OrderBy(s => s.Price);
                        dg.DataSource = c.Paintings.Include("Author").Include("Genre").ToList();
                        dg.DataSource = p.ToList();
                    }
                }
                if (colname == "Year")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Paintings.OrderBy(s => s.Year);
                        dg.DataSource = c.Paintings.Include("Author").Include("Genre").ToList();
                        dg.DataSource = p.ToList();
                    }
                }
                if (colname == "Author")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Paintings.OrderBy(s => s.Author);
                        dg.DataSource = c.Paintings.Include("Author").Include("Genre").ToList();
                        dg.DataSource = p.ToList();
                    }
                }
                if (colname == "Genre")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Paintings.OrderBy(s => s.Genre);
                        dg.DataSource = c.Paintings.Include("Author").Include("Genre").ToList();
                        dg.DataSource = p.ToList();
                    }
                }
            }
            if (table == "Жанры")
            {
                if (colname == "Id")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Genres.OrderBy(s => s.Id);
                        dg.DataSource = p.ToList();
                    }
                }
                if (colname == "Name")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Genres.OrderBy(s => s.Name);
                        dg.DataSource = p.ToList();
                    }
                }
            }
            if (table == "Авторы")
            {
                if (colname == "Id")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Authors.OrderBy(s => s.Id);
                        dg.DataSource = p.ToList();
                    }
                }
                if (colname == "Name")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Authors.OrderBy(s => s.Name);
                        dg.DataSource = p.ToList();
                    }
                }
                if (colname == "Bio")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Authors.OrderBy(s => s.Bio);
                        dg.DataSource = p.ToList();
                    }
                }
            }
            if (table == "Сотрудники")
            {
                if (colname == "Id")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Employees.OrderBy(s => s.Id);
                        dg.DataSource = p.ToList();
                    }
                }
                if (colname == "Name")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Employees.OrderBy(s => s.Name);
                        dg.DataSource = p.ToList();
                    }
                }
            }
            if (table == "Журнал передвижения картин")
            {
                if (colname == "Id")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Journals.OrderBy(s => s.Id);
                        dg.DataSource = c.Journals.Include("Painting").Include("Employee").Include("From").Include("To").ToList();
                        dg.DataSource = p.ToList();
                    }
                }
                if (colname == "Name")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Journals.OrderBy(s => s.Oper_date);
                        dg.DataSource = c.Journals.Include("Painting").Include("Employee").Include("From").Include("To").ToList();
                        dg.DataSource = p.ToList();
                    }
                }
            }
            if (table == "Выставки")
            {
                if (colname == "Id")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Exhibitions.OrderBy(s => s.Id);
                        dg.DataSource = p.ToList();
                    }
                }
                if (colname == "Name")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Exhibitions.OrderBy(s => s.Name);
                        dg.DataSource = p.ToList();
                    }
                }
                if (colname == "Place")
                {
                    using (gallContext c = new gallContext())
                    {
                        var p = c.Exhibitions.OrderBy(s => s.Place);
                        dg.DataSource = p.ToList();
                    }
                }
            }
        }
    }
}
