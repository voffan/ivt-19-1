using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gallerys;
using gallerys.Context;
using gallerys.components;
using gallerys.Models;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace gallerys.Forms.FormsforAdd
{
    public partial class AddExhibition : Form
    {
        public AddExhibition(string s, string s1)
        {
            InitializeComponent();
            this.Text = s + " " + s1;
        }
        int idn;
        private void button1_Click(object sender, EventArgs e)
        {
            ExhiSer es = new ExhiSer();
            if (this.Text == "Добавить Выставки")
            {
                es.Add(textBox1.Text, textBox2.Text);
                MessageBox.Show("Вы успешно добавили");
            }
            else
            {
                es.Edit(idn, textBox1.Text, textBox2.Text);
                MessageBox.Show("Вы успешно отредактировали");
            }
            this.Close();
        }

        private void AddExhibition_Load(object sender, EventArgs e)
        {
            ExhiSer es = new ExhiSer();
            if (this.Text == "Редактировать Выставки")
            {
                idn = es.ReturnId(textBox1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
