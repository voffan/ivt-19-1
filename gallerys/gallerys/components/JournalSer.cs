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
    public class JournalSer
    {
        public void Add(DateTime date, int paint, int pfrom, int pto, int emid)
        {
            Journal j = new Journal()
            {
                Oper_date = date,
                PaintingId = paint,
                EmployeeId = emid,
                FromId = pfrom,
                ToId = pto
            };
            using (gallContext db = Connection.Connect())
            {
                db.Journals.Add(j);
                db.SaveChanges();
            }

        }
        public void Edit(int id, DateTime date, int paint, int pfrom, int pto, int emid)
        {
            Journal j = new Journal();
            using (gallContext db = Connection.Connect())
            {
                j = db.Journals.Find(id);
                j.Oper_date = date;
                j.PaintingId = paint;
                j.FromId = pfrom;
                j.EmployeeId = emid;
                j.ToId = pto;
                db.Entry(j).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Remove(int id)
        {
            using (gallContext db = Connection.Connect())
            {
                db.Journals.Remove(db.Journals.First(p => p.Id == id));
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
        public int ReturnId(DateTimePicker d, ComboBox box)
        {
            using (gallContext db = Connection.Connect())
            {
                Journal empl = db.Journals.Where(p => p.Oper_date == d.Value && p.PaintingId == Convert.ToInt32(box.SelectedValue)).FirstOrDefault();

                if (empl == null)
                {
                    throw new Errors.UserErrors("Ошибка возвращения идентификатора жанра");
                }
                return empl.Id;
            }
        }
        public void ReturnCombobox(ComboBox c1)
        {
            gallContext c = new gallContext();
            List<Painting> paint = c.Paintings.ToList();
            DataTable dt = new DataTable();      
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            foreach (Painting usepurpose in paint)
            {
                dt.Rows.Add(usepurpose.Id, usepurpose.Name);
            }
            c1.ValueMember = dt.Columns[0].ColumnName;
            c1.DisplayMember = dt.Columns[1].ColumnName;
            c1.DataSource = dt;
        }
        public void ReturnCombo(ComboBox c1)
        {
            gallContext c = new gallContext();
            List<Place> place = c.Places.ToList();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id");
            dt1.Columns.Add("name");
            foreach (Place usepurpose in place)
            {
                dt1.Rows.Add(usepurpose.Id, usepurpose.Name);
            }
            c1.ValueMember = dt1.Columns[0].ColumnName;
            c1.DisplayMember = dt1.Columns[1].ColumnName;
            c1.DataSource = dt1;
        }
    }
}
