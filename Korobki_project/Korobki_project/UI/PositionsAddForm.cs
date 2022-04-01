using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Korobki_project.UI
{
    public partial class PositionsAddForm : Form
    {
        public PositionsAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length!=0)
            {
                string connStr = "server=localhost; port=3306; username=root; password=root; database=korobkibd;";
                string sql = "INSERT positions(Name)" + "VALUES('" + textBox1.Text + "')";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Добавлено");
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

		private void PositionsAddForm_FormClosed(object sender, FormClosedEventArgs e)
		{
            MenuForm main = new MenuForm();
            main.Show();
        }
	}
}
