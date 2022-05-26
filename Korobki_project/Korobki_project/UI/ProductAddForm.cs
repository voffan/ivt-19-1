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
using Korobki_project.Functions;

namespace Korobki_project.UI
{
    public partial class ProductAddForm : Form
    {
        public ProductAddForm()
        {
            InitializeComponent();
        }

        private void ProductsAddForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = (new Context()).Typees.ToList();
            comboBox1.DisplayMember = "Type_name";
            comboBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int c1 = Convert.ToInt32(comboBox1.SelectedValue);
            string size_box = textBox1.Text;
            if (textBox1.Text.Length != 0)
            {
                /*
                string connStr = "server=localhost; port=3306; username=root; password=root; database=korobkibd;";
                string sql = "INSERT products(TypeeId, Size_box)" + "VALUES(" + c1 + ", '" + textBox1.Text + "')";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                */
                ProductFunctions productFunctions = new ProductFunctions();
                productFunctions.Add(c1, size_box);
                MessageBox.Show("Добавлено");
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
	}
}
