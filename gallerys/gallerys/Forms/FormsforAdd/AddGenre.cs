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
    public partial class AddGenre : Form
    {
        public AddGenre(string s, string s1)
        {
            InitializeComponent();
            this.Text = s + " " + s1;
        }
        int idn;
        private void button1_Click(object sender, EventArgs e)
        {
            string genre = textBox1.Text;
            JanrSer j = new JanrSer();
            if (this.Text == "Редактировать Жанры")
            {
                j.Edit(idn, genre);
            }
            else
            {
                j.Add(genre);
            }
            MessageBox.Show("Вы успешно добавили жанр");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddGenre_Load(object sender, EventArgs e)
        {
            if(this.Text == "Редактировать Жанры")
            {
                JanrSer j = new JanrSer();
                idn = j.ReturnId(textBox1);
            }
        }
    }
}
