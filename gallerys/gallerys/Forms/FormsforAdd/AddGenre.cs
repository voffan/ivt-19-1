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
                MessageBox.Show("Вы успешно отредактировали");
                this.Close();
            }
            else
            {
                if (j.proverka(genre))
                {
                    j.Add(genre);
                    MessageBox.Show("Вы успешно добавили");
                    this.Close();
                }
                else MessageBox.Show("Такой жанр уже существует", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
