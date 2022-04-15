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

        private void button1_Click(object sender, EventArgs e)
        {
            string genre = textBox1.Text;
            JanrSer j = new JanrSer();
            j.Add(genre);
            MessageBox.Show("Вы успешно добавили жанр");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
