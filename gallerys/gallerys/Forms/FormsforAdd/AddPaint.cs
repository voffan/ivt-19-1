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
        int idn;
        private void button1_Click(object sender, EventArgs e)
        {
            PaintSer p = new PaintSer();
            gallContext c = new gallContext();
            var stat = (status)Enum.Parse(typeof(status), comboBox1.SelectedValue.ToString());
            MessageBox.Show(Convert.ToInt32(comboBox2.SelectedValue).ToString());
            if (this.Text == "Редактировать Картины")
            {
                p.Edit(idn, textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), stat, Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox3.SelectedValue));
            }
            else
            {
                p.Add(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), stat, Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox3.SelectedValue));
            }
        }
        private void AddPaint_Load(object sender, EventArgs e)
        {
            PaintSer p = new PaintSer();
            p.comboxAuthor(comboBox2);
            p.comboxStatus(comboBox1);
            p.comboxGenre(comboBox3);
            idn = p.ReturnId(textBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
