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
using gallerys.components;

namespace gallerys.Forms.FormsforAdd
{
    public partial class AddJournal : Form
    {
        public AddJournal(string s, string s1)
        {
            InitializeComponent();
            this.Text = s + " " + s1;
        }
        int idn;
        int idem;
        private void button1_Click(object sender, EventArgs e)
        {
            JournalSer js = new JournalSer();
            if (this.Text == "Добавить Журнал передвижения картин")
            {
                js.Add(dateTimePicker1.Value, Convert.ToInt32(comboBoxPaint.SelectedValue), Convert.ToInt32(comboBoxFrom.SelectedValue), Convert.ToInt32(comboBoxTo.SelectedValue), idem);
                MessageBox.Show("Вы успешно добавили");
            }
            else
            {
                js.Edit(idn, dateTimePicker1.Value, Convert.ToInt32(comboBoxPaint.SelectedValue), Convert.ToInt32(comboBoxFrom.SelectedValue), Convert.ToInt32(comboBoxTo.SelectedValue), idem);
                MessageBox.Show("Вы успешно отредактировали");
            }
            this.Close();
        }

        private void AddJournal_Load(object sender, EventArgs e)
        {
            JournalSer js = new JournalSer();
            js.ReturnCombobox(comboBoxPaint);
            js.ReturnCombo(comboBoxFrom);
            js.ReturnCombo(comboBoxTo);
            if (this.Text == "Редактировать Журнал передвижения картин")
            {
                idn = js.ReturnId(dateTimePicker1);
                using (gallContext c = new gallContext())
                {
                    Journal pa = c.Journals.Where(b => b.Id == idn).FirstOrDefault();
                    comboBoxPaint.SelectedValue = pa.PaintingId;
                    comboBoxFrom.SelectedValue = pa.FromId;
                    comboBoxTo.SelectedValue = pa.ToId;
                }
            }
            idem = Connection.employeeSer.CurrentEmployee.Id; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
