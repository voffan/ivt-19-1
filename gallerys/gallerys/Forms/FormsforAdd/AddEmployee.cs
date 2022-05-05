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
    public partial class AddEmployee : Form
    {
        public AddEmployee(string s, string s1)
        {
            InitializeComponent();
            this.Text = s + " " + s1;
        }
        int idn;
        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeSer employeeSer = new EmployeeSer();
            string surname = textBox1.Text;
            string name = textBox2.Text;
            string otchestvo = textBox3.Text;
            string login = textBox4.Text;
            string pass = textBox5.Text;
            var right = (Right)Enum.Parse(typeof(Right), comboBoxRight.SelectedValue.ToString());
            if (this.Text == "Добавить Сотрудники")
            {
                employeeSer.Add(surname + " " + name + " " + otchestvo, login, pass, right);
                MessageBox.Show("Вы успешно добавили сотрудника");
            }
            else
            {
                employeeSer.Edit(idn, surname + " " + name + " " + otchestvo, login, pass, right);
                MessageBox.Show("Вы успешно отредактировали");
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            EmployeeSer em = new EmployeeSer();
            if (this.Text == "Редактировать Сотрудника")
            {
                idn = em.ReturnId(textBox1, textBox2, textBox3);
            }
            comboBoxRight.DataSource = new BindingSource(DescriptionAttributes<Right>.RetrieveAttributes(), null);
            comboBoxRight.DisplayMember = "Key";
            comboBoxRight.ValueMember = "Value";
        }

    }
}
