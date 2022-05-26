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
                string name = textBox1.Text;
                /* 
                 string connStr = "server=localhost; port=3306; username=root; password=root; database=korobkibd;";
                 string sql = "INSERT positions(Name)" + "VALUES('" + textBox1.Text + "')";
                 MySqlConnection conn = new MySqlConnection(connStr);
                 conn.Open();
                 MySqlCommand command = new MySqlCommand(sql, conn);
                 command.ExecuteNonQuery();
                 conn.Close();
                */
                PositionFunctions positionFunctions = new PositionFunctions();
                positionFunctions.Add(name);
                MessageBox.Show("Добавлено");
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
	}
}
