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
            PaintSer p = new PaintSer();
            var author = (Author)comboBox2.SelectedValue;
            var stat = (status)Enum.Parse(typeof(status), comboBox1.SelectedValue.ToString());
            var g = (Genre)comboBox3.SelectedItem;
            p.Add(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), stat, author, g);
        }

        private void AddPaint_Load(object sender, EventArgs e)
        {
            if (this.Text == "Редактировать Картины")
            {
                PaintSer p = new PaintSer();
            }
            else
            {
                PaintSer p = new PaintSer();
                p.comboxAuthor(comboBox2);
                p.comboxStatus(comboBox1);
                p.comboxGenre(comboBox3);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
