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
    public partial class AddPaint : Form
    {
        public AddPaint(string s, string s1)
        {
            InitializeComponent();
            this.Text = s + " " + s1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //status s = comboBox1.Text;
            //PaintSer p = new PaintSer();
            //p.Add(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), )
        }

        private void AddPaint_Load(object sender, EventArgs e)
        {
            gallContext c = new gallContext();
            //comboBox1.DataSource = Enum.GetValues(typeof(status)).Cast<Painting>();
            List<Painting> stat = c.Paintings.ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            foreach (Painting usepurpose in stat)
            {
                dt.Rows.Add(usepurpose.AuthorId, usepurpose.Author);
            }
            comboBox2.ValueMember = dt.Columns[0].ColumnName;
            comboBox2.DisplayMember = dt.Columns[1].ColumnName;
            comboBox2.DataSource = dt;
        }
    }
}
