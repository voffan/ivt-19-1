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
    public partial class ProductionAddForm : Form
    {
        public ProductionAddForm()
        {
            InitializeComponent();
        }

        private void ProductionAddForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = (new Context()).Schedules.ToList();
            comboBox1.DisplayMember = "Date";
            comboBox1.ValueMember = "Id";

            comboBox2.DataSource = (new Context()).Products.ToList();
            comboBox2.DisplayMember = "Size_box";
            comboBox2.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0 && textBox2.TextLength != 0)
            {
                int c1 = comboBox1.SelectedIndex + 1;
                int c2 = comboBox2.SelectedIndex + 1;
                string connStr = "server=localhost; port=3306; username=root; password=root; database=korobkibd;";
                string sql = "INSERT productions(TeamId, ProductId, Count, Comment) " +
                    "VALUES(" + c1 + ", " + c2 + ", '" + textBox1.Text + "',  '" + textBox2.Text + "');";
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

        private void ProductionAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuForm main = new MenuForm();
            main.Show();
        }
    }
}
