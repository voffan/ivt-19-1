using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Standings.Functions;
using Standings.Models;
using MySql.Data.MySqlClient;
using Standings.Database;

namespace Standings.Forms
{
    public partial class UpdateEmployee : Form
    {
        public UpdateEmployee()
        {
            InitializeComponent();
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FullName = FullName1.Text,
                Password1 = password1.Text,
                Password2 = password2.Text;

            Position Position = (Position)Enum.Parse(typeof(Position), comboBox1.Text);
            if (Password1 == Password2)
            {
                if (FullName1.Text == "" || comboBox1.Text == "" || password1.Text == "" || password2.Text == "")
                {
                    MessageBox.Show("Заполните ВСЕ поля!");
                }
                else
                {
                    using (Context db = Connection.Connect())
                    {
                        //EmployeeFunctions.Edit(Password1, FullName, Position);

                        this.Close();

                    }
                }
            }
            else
            {
                MessageBox.Show("Ваши пароли не совподают!");
            }
        }
    }
}
