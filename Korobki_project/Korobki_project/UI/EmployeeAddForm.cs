using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Korobki_project.UI
{
	public partial class EmployeeAddForm : Form
	{
		public EmployeeAddForm()
		{
			InitializeComponent();
		}

		private void EmployeeAddForm_Load(object sender, EventArgs e)
		{
			comboBox1.DataSource = (new Context()).Positions.ToList();
			comboBox1.DisplayMember = "Name";
			comboBox1.ValueMember = "Id";

			comboBox2.DataSource = (new Context()).Shifts.ToList();
			comboBox2.DisplayMember = "Name";
			comboBox2.ValueMember = "Id";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox3.TextLength != 0 && textBox4.TextLength != 0 && textBox5.TextLength != 0)
			{
				string c1 = comboBox1.SelectedValue.ToString();
				string c2 = comboBox2.SelectedValue.ToString();
				//int id = 4;
				string connStr = "server=localhost; port=3306; username=root; password=root; database=korobkibd;";
				string sql = "INSERT employees(Name, Login, Password, PositionId, PhoneNumber, Adress, ShiftId) " +
					"VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', " + c1 + ",  '" + textBox4.Text + "', '" + textBox5.Text + "', " + c2 + ");";

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

        
    }
}
