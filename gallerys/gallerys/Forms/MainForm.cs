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
using gallerys.Models;
using Microsoft.Office.Interop.Excel;
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
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InitTable();
        }
        private void Addbutton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
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
                    if (comboBox1.Text == "Выставки")
                    {
                        AddExhibition add = new AddExhibition(s, comboBox1.Text);
                        add.ShowDialog();
                    }
                    if (comboBox1.Text == "Журнал передвижения картин")
                    {
                        AddJournal add = new AddJournal(s, comboBox1.Text);
                        add.ShowDialog();
                    }
                    InitTable();
                }
                else
                {
                    MessageBox.Show("Вы не можете добавлять");
                }
            }
        }
        private void InitTable()
        {
            gallContext c = new gallContext();
            string selectedtable = comboBox1.SelectedItem.ToString();
            if ((Connection.employeeSer.CurrentEmployee.Right == 0) || (Connection.employeeSer.CurrentEmployee.Right == Models.Right.manager))
            {
                if (selectedtable == "Картины")
                {
                    dataGridView1.DataSource = c.Paintings.ToList();
                    dataGridView1.DataSource = c.Paintings.Include("Author").Include("Genre").ToList();
                    dataGridView1.Columns[4].Visible = false;
                }
                if (selectedtable == "Сотрудники")
                {
                    dataGridView1.DataSource = c.Employees.ToList();
                    dataGridView1.Columns[4].Visible = false;
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
                    dataGridView1.DataSource = c.Journals.Include("Painting").Include("Employee").Include("From").Include("To").ToList();
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
                    dataGridView1.DataSource = c.Paintings.Include("Author").ToList();
                    dataGridView1.DataSource = c.Paintings.Include("Genre").ToList();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                }
                if (selectedtable == "Сотрудники" && !(Connection.employeeSer.CurrentEmployee.Right == Models.Right.restorer))
                {
                    dataGridView1.DataSource = c.Employees.ToList();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                }
                //else MessageBox.Show("Вам закрыт доступ");
                if (selectedtable == "Жанры" && !(Connection.employeeSer.CurrentEmployee.Right == Models.Right.director) && !(Connection.employeeSer.CurrentEmployee.Right == Models.Right.restorer))
                {
                    dataGridView1.DataSource = c.Genres.ToList();
                    dataGridView1.Columns[0].Visible = false;
                }
                //else MessageBox.Show("Вам закрыт доступ");
                if (selectedtable == "Авторы" && !(Connection.employeeSer.CurrentEmployee.Right == Models.Right.director))
                {
                    dataGridView1.DataSource = c.Authors.ToList();
                    dataGridView1.Columns[0].Visible = false;
                }
                //else MessageBox.Show("Вам закрыт доступ");
                if (selectedtable == "Журнал передвижения картин" && !(Connection.employeeSer.CurrentEmployee.Right == Models.Right.director) && !(Connection.employeeSer.CurrentEmployee.Right == Models.Right.restorer))
                {
                    dataGridView1.DataSource = c.Journals.ToList();
                    dataGridView1.Columns[0].Visible = false;
                }
                //else MessageBox.Show("Вам закрыт доступ");
                if (selectedtable == "Выставки" && !(Connection.employeeSer.CurrentEmployee.Right == Models.Right.director) && !(Connection.employeeSer.CurrentEmployee.Right == Models.Right.restorer))
                {
                    dataGridView1.DataSource = c.Exhibitions.ToList();
                    dataGridView1.Columns[0].Visible = false;
                }
                else MessageBox.Show("Вам закрыт доступ");
            }
            label1.Text = "Текущий список: " + selectedtable;
        }
        public int idn;
        private void Editbutton_Click(object sender, EventArgs e)
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
                    idn = dataGridView1.CurrentRow.Index;
                    if ((Connection.employeeSer.CurrentEmployee.Right == 0) || (Connection.employeeSer.CurrentEmployee.Right == Models.Right.manager))
                    {
                        if (comboBox1.Text == "Картины")
                        {
                            AddPaint add = new AddPaint(s, comboBox1.Text);
                            add.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                            add.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                            add.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                            //add.comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value;
                            //add.comboBox2.SelectedValue = dataGridView1.CurrentRow.Cells[5].Value;
                            add.ShowDialog();
                        }
                        if (comboBox1.Text == "Жанры")
                        {
                            AddGenre add = new AddGenre(s, comboBox1.Text);
                            add.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                            add.ShowDialog();
                        }
                        if (comboBox1.Text == "Авторы")
                        {
                            AddAuthors add = new AddAuthors(s, comboBox1.Text);
                            add.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                            add.textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                            add.ShowDialog();
                        }
                        if (comboBox1.Text == "Сотрудники")
                        {
                            AddEmployee add = new AddEmployee(s, comboBox1.Text);
                            string sp = dataGridView1.Rows[idn].Cells[1].Value.ToString();
                            string[] sp1 = sp.Split(" ");
                            add.textBox1.Text = sp1[0];
                            add.textBox2.Text = sp1[1];
                            add.textBox3.Text = sp1[2];
                            add.textBox4.Text = dataGridView1.Rows[idn].Cells[2].Value.ToString();
                            add.textBox5.Text = dataGridView1.Rows[idn].Cells[3].Value.ToString();
                            add.ShowDialog();
                        }
                        if (comboBox1.Text == "Журнал передвижения картин")
                        {
                            AddJournal add = new AddJournal(s, comboBox1.Text);
                            Journal j = new Journal();
                            using (gallContext db = Connection.Connect())
                            {
                                j = db.Journals.Find(dataGridView1.Rows[idn].Cells[0].Value);
                                add.dateTimePicker1.Value = j.Oper_date;
                                //add.comboBoxPaint.SelectedValue = j.PaintingId;
                                //add.comboBoxFrom.SelectedValue = j.FromId;
                                //add.comboBoxTo.SelectedValue = j.ToId;
                            }
                            add.ShowDialog();
                        }
                        if (comboBox1.Text == "Выставки")
                        {
                            AddExhibition add = new AddExhibition(s, comboBox1.Text);
                            add.textBox1.Text = dataGridView1.Rows[idn].Cells[2].Value.ToString();
                            add.textBox2.Text = dataGridView1.Rows[idn].Cells[1].Value.ToString();
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

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sortbystring sr = new sortbystring();
            sr.sorting(comboBox1.SelectedItem.ToString(), dataGridView1.Columns[e.ColumnIndex].Name, dataGridView1);
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            if ((Connection.employeeSer.CurrentEmployee.Right == 0) || (Connection.employeeSer.CurrentEmployee.Right == Models.Right.manager))
            {
                gallContext c = new gallContext();
                string selectedtable = comboBox1.SelectedItem.ToString();
                int idn = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                DialogResult res = MessageBox.Show("Вы точно хотите удалить?", "Удаление", MessageBoxButtons.YesNo);
                if (selectedtable == "Картины")
                {
                    //DialogResult res = MessageBox.Show("Вы точно хотите удалить?", "Удаление", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        PaintSer ps = new PaintSer();
                        ps.Remove(idn);
                    }
                }
                if (selectedtable == "Сотрудники")
                {
                    //DialogResult res = MessageBox.Show("Вы точно хотите удалить?", "Удаление", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        EmployeeSer es = new EmployeeSer();
                        es.Remove(idn);
                    }
                }
                if (selectedtable == "Жанры")
                {
                    //DialogResult res = MessageBox.Show("Вы точно хотите удалить?", "Удаление", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        JanrSer js = new JanrSer();
                        js.Remove(idn);
                    }
                }
                if (selectedtable == "Авторы")
                {
                    //DialogResult res = MessageBox.Show("Вы точно хотите удалить?", "Удаление", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        AutorSer aus = new AutorSer();
                        aus.Remove(idn);
                    }
                }
                if (selectedtable == "Журнал передвижения картин")
                {
                    if (res == DialogResult.Yes)
                    {
                        JournalSer js = new JournalSer();
                        js.Remove(idn);
                    }
                }
                if (selectedtable == "Выставки")
                {
                    //DialogResult res = MessageBox.Show("Вы точно хотите удалить?", "Удаление", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        ExhiSer es = new ExhiSer();
                        es.Remove(idn);
                    }
                }
                if (res == DialogResult.Yes)
                    MessageBox.Show("Вы успешно удалили");
            }
            else
            {
                MessageBox.Show("У вас нет прав удалять");
            }
            InitTable();
        }

        private void Poiskbutton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите таблицу");
            }
            else
            {
                string selectedtable = comboBox1.SelectedItem.ToString();
                using (gallContext context = new gallContext())
                {
                    if (selectedtable == "Картины")
                    {
                        dataGridView1.DataSource = PaintSer.Search(textBox1.Text);
                    }
                    if (Connection.employeeSer.CurrentEmployee.Right == Models.Right.manager || Connection.employeeSer.CurrentEmployee.Right == Models.Right.admin)
                    {
                        if (selectedtable == "Авторы")
                        {
                            dataGridView1.DataSource = AutorSer.Search(textBox1.Text);
                        }
                        //else MessageBox.Show("Вам закрыт доступ");
                        if (selectedtable == "Сотрудники")
                        {
                            dataGridView1.DataSource = EmployeeSer.Search(textBox1.Text);
                        }
                        //else MessageBox.Show("Вам закрыт доступ");
                        if (selectedtable == "Выставки")
                        {
                            dataGridView1.DataSource = ExhiSer.Search(textBox1.Text);
                        }
                        //else MessageBox.Show("Вам закрыт доступ");
                        if (selectedtable == "Жанры")
                        {
                            dataGridView1.DataSource = JanrSer.Search(textBox1.Text);
                        }
                    }
                    else if (Connection.employeeSer.CurrentEmployee.Right == Models.Right.restorer || Connection.employeeSer.CurrentEmployee.Right == Models.Right.director)
                    {
                        if (selectedtable == "Авторы" && Connection.employeeSer.CurrentEmployee.Right != Models.Right.director)
                        {
                            dataGridView1.DataSource = AutorSer.Search(textBox1.Text);
                        }
                        if (selectedtable == "Сотрудники" && Connection.employeeSer.CurrentEmployee.Right != Models.Right.restorer)
                        {
                            dataGridView1.DataSource = EmployeeSer.Search(textBox1.Text);
                        }
                        else MessageBox.Show("Вам закрыт доступ");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Connection.employeeSer.CurrentEmployee.Right == Models.Right.manager)
            {
                string path = "";
                report rep = new report();
                path = rep.openfile();
                rep.restoration(path);
                rep.clos(path);
                MessageBox.Show("Файл успешно создан");
            }
            else MessageBox.Show("У вас нет прав");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Connection.employeeSer.CurrentEmployee.Right == Models.Right.manager)
            {
                string path = "";
                report rep = new report();
                path = rep.openfile();
                rep.exhibrep(path);
                rep.clos(path);
                MessageBox.Show("Файл успешно создан");
            }
            else MessageBox.Show("У вас нет прав");
        }
    }
}
