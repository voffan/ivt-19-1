using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Standings.Database;
using MySql.Data.MySqlClient;
using Standings.Functions;
using Standings.Models;

namespace Standings.Forms
{
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FullName = FullName1.Text,
                Login = Login1.Text,
                Password1 = password1.Text,
                Password2 = password2.Text;

            Position pos = (Position)Enum.Parse(typeof(Position), comboBox1.Text);
            if (Password1 == Password2)
            {
                if (FullName1.Text == "" || comboBox1.Text == "" || Login1.Text == "" || password1.Text == "" || password2.Text == "")
                {
                    MessageBox.Show("Заполните ВСЕ поля!");
                }
                else
                {
                        EmployeeFunctions.Add(Login, Password1, FullName, pos);

                        this.Close();
                }

            }
            else
            {
                MessageBox.Show("Ваши пароли не совподают!");
            }
        }

        private void Login1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FullName1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(Position));
        }
    }
}
