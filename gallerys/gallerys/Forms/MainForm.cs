using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gallerys;
using gallerys.Context;
using Microsoft.EntityFrameworkCore;
using gallerys.Forms;
namespace gallerys
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        Form addForm;
        private void MainForm_Load(object sender, EventArgs e)
        {
            gallContext c = new gallContext();
            MessageBox.Show("Приветствую вас, ");
        }


        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            gallContext c = new gallContext();
            string selectedtable = comboBox1.SelectedItem.ToString();
            if (selectedtable == "Картины")
            {
                dataGridView1.DataSource = c.Paintings.ToList();
            }
            if (selectedtable == "Сотрудники")
            {
                dataGridView1.DataSource = c.Employees.ToList();
            }
            if (selectedtable == "Жанры")
            {
                dataGridView1.DataSource = c.Genres.ToList();
            }
            if (selectedtable == "Авторы")
            {
                dataGridView1.DataSource = c.Authors.ToList();
            }
            if (selectedtable == "Журнал передвижения картин")
            {
                dataGridView1.DataSource = c.Journals.ToList();
            }
            if (selectedtable == "Выставки")
            {
                dataGridView1.DataSource = c.Exhibitions.ToList();
            }
            label1.Text = "Текущий список: " + selectedtable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addForm.ShowDialog(this);
        }
    }
}
