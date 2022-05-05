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
    public partial class AddAuthors : Form
    {
        public AddAuthors(string s, string s1)
        {
            InitializeComponent();
            this.Text = s + " " + s1;
        }
        int idn;
        private void button1_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            string bio = textBox4.Text;
            AutorSer autorSer = new AutorSer();
            if (this.Text == "Добавить Авторы")
            {
                autorSer.Add(surname, bio);
                MessageBox.Show("Вы успешно добавили автора");
            }
            else
            {
                autorSer.Edit(idn, surname, bio);
                MessageBox.Show("Вы успешно отредактировали");
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAuthors_Load(object sender, EventArgs e)
        {
            AutorSer ars = new AutorSer();
            if (this.Text == "Редактировать Авторы")
            {
                idn = ars.ReturnId(textBox1);
            }
        }
    }
}
