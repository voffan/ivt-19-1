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
using gallerys.Forms.FormsforAdd;
using gallerys.components;
namespace gallerys
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            gallContext c = new gallContext();
        }


        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InitTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "Добавить";
            //Картины Жанры Авторы Сотрудники Журнал передвижения картин Выставки
            if ((Connection.employeeSer.CurrentEmployee.Right == 0) || (Connection.employeeSer.CurrentEmployee.Right == Models.Right.manager))
            {
                if (comboBox1.Text == "Картины")
                {
                    AddPaint add = new AddPaint(s, comboBox1.Text);
                    add.ShowDialog();
                }
                if (comboBox1.Text == "Жанры")
                {
                    AddGenre add = new AddGenre(s, comboBox1.Text);
                    add.ShowDialog();
                }
                if (comboBox1.Text == "Авторы")
                {
                    AddAuthors add = new AddAuthors(s, comboBox1.Text);
                    add.ShowDialog();
                }
                if (comboBox1.Text == "Сотрудники")
                {
                    AddEmployee add = new AddEmployee(s, comboBox1.Text);
                    add.ShowDialog();
                }
                InitTable();
            }
            else
            {
                MessageBox.Show("Вы не можете добавлять");
            }
        }
        private void InitTable()
        {
            gallContext c = new gallContext();
            string selectedtable = comboBox1.SelectedItem.ToString();
            if ((Connection.employeeSer.CurrentEmployee.Right == 0))
            {
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
            }
            else
            {
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
            }
            label1.Text = "Текущий список: " + selectedtable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "Редактировать";
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Выберите таблицу");
            }
            //Картины Жанры Авторы Сотрудники Журнал передвижения картин Выставки
            else
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int p = dataGridView1.CurrentRow.Index;
                    if ((Connection.employeeSer.CurrentEmployee.Right == 0) || (Connection.employeeSer.CurrentEmployee.Right == Models.Right.manager))
                    {
                        if (comboBox1.Text == "Картины")
                        {
                            AddPaint add = new AddPaint(s, comboBox1.Text);
                            add.textBox1.Text = dataGridView1.Rows[p].Cells[1].Value.ToString();

                            add.ShowDialog();
                        }
                        if (comboBox1.Text == "Жанры")
                        {
                            AddGenre add = new AddGenre(s, comboBox1.Text);
                            add.ShowDialog();
                        }
                        if (comboBox1.Text == "Авторы")
                        {
                            AddAuthors add = new AddAuthors(s, comboBox1.Text);
                            add.ShowDialog();
                        }
                        if (comboBox1.Text == "Сотрудники")
                        {
                            AddEmployee add = new AddEmployee(s, comboBox1.Text);
                            string sp = dataGridView1.Rows[p].Cells[1].Value.ToString();
                            string[] sp1 = sp.Split(" ");
                            add.textBox1.Text = sp1[0];
                            add.textBox2.Text = sp1[1];
                            add.textBox3.Text = sp1[2];
                            add.textBox4.Text = dataGridView1.Rows[p].Cells[2].Value.ToString();
                            add.textBox5.Text = dataGridView1.Rows[p].Cells[3].Value.ToString();
                            add.ShowDialog();
                        }
                        InitTable();
                    }
                    else
                    {
                        MessageBox.Show("Вы не можете добавлять");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите редактируемый объект");
                }
            }
        }
    }
}
