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

namespace Standings
{
    public partial class Registration : Form
    {

        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Context connect = new Context();
            Autorization autor = new Autorization();
            string FullName = FullName1.Text,
                Category = Category1.Text,
                Login = Login1.Text,
                Password1 = password1.Text,
                Password2 = password2.Text;
                
            if (Password1 == Password2)
            {
                if(FullName1.Text == "" || Category1.Text == "" || Login1.Text == "" || password1.Text == "" || password2.Text == "")
                {
                    MessageBox.Show("Заполните ВСЕ поля!");
                }
                else
                {
                    using (Context db = Connection.Connect())
                    {
                        JudgeFunctions.Register(Login, Password1, FullName, Category, dateTimePicker1.Value);
                        
                        this.Close();
                        autor.Show();

                    }
                }

            }
            else
            {
                MessageBox.Show("Ваши пароли не совподают!");
            }


            //INSERT INTO `standings`.`judges` (`Id`, `Login`, `Password`, `FullNname`, `Category`, `Experience`) VALUES('2', 'ganya', '111', 'ganyaa', 'Фокс', '2001-12-01');

        }

        private void Login1_TextChanged(object sender, EventArgs e)
        {

        }

        private void password1_TextChanged(object sender, EventArgs e)
        {

        }

        private void password2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Category1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
