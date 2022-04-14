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
    public partial class PlanFromAdd : Form
    {
        public PlanFromAdd()
        {
            InitializeComponent();
        }

        private void PlanFromAdd_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = (new Context()).Products.ToList();
            comboBox1.DisplayMember = "Size_box";
            comboBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length!=0)
            {
                int c1 = comboBox1.SelectedIndex + 1;
                int count = Convert.ToInt32(textBox1.Text);
                string connStr = "server=localhost; port=3306; username=root; password=root; database=korobkibd;";
                string sql = "INSERT plans(Count_box, PlanDate,ProductId)" + "VALUES(" + count + ", '" + dateTimePicker1.Value.Date.ToString("dd.MM.yyyy") + "'," + c1 + ")";
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

		private void PlanFromAdd_FormClosed(object sender, FormClosedEventArgs e)
		{
            MenuForm main = new MenuForm();
            main.Show();
        }
	}
}
