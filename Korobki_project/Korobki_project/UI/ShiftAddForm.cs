using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Korobki_project.UI;
using MySql.Data.MySqlClient;
using Korobki_project.Functions;

namespace Korobki_project.Classes
{
    public partial class ShiftAddForm : Form
    {
        public ShiftAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                /*string connStr = "server=localhost; port=3306; username=root; password=root; database=korobkibd;";
                string sql = "INSERT shifts(Name)" + "VALUES('" + textBox1.Text + "')";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();*/
                ShiftFunctions shift = new ShiftFunctions();
                shift.Add(textBox1.Text);
                MessageBox.Show("Добавлено");
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
