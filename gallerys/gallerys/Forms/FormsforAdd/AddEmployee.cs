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

        private void button1_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            string name = textBox2.Text;
            string otchestvo = textBox3.Text;
            string login = textBox4.Text;
            string pass = textBox5.Text;
            string right = comboBox1.Text;
            EmployeeSer employeeSer = new EmployeeSer();
            employeeSer.Add(surname + name + otchestvo, login, pass, right);
            MessageBox.Show("Вы успешно добавили сотрудника");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
