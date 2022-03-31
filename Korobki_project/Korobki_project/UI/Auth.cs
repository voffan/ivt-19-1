using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Korobki_project;
using Microsoft.EntityFrameworkCore;
using Korobki_project.UI;
using MySql.Data.MySqlClient;

namespace Korobki_project
{
	public partial class Auth : Form
	{
		public Auth()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

        private void button1_Click(object sender, EventArgs e)
        {
			/*
			this.Hide();
			MenuForm main = new MenuForm();
			main.Show();
			*/

			Context c = new Context();
			
			string connStr = "server=localhost; port=3306; username=root; password=1234; database=korobkibd;";
			string sql = "SELECT * FROM employees WHERE Login = @un and  Password = @up";

			MySqlConnection conn = new MySqlConnection(connStr);
			conn.Open();

			DataTable table = new DataTable();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand command = new MySqlCommand(sql, conn);
			command.Parameters.Add("@un", MySqlDbType.VarChar, 25);
			command.Parameters.Add("@up", MySqlDbType.VarChar, 25);

			command.Parameters["@un"].Value = login.Text;
			command.Parameters["@up"].Value = password.Text;

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count > 0)
			{
				userRole(); // метод, который будет открывать разные формы в зависимости от пользователя
			}
			else
			{
				MessageBox.Show("Login or password nepravilniy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			conn.Close();

		}

		private void userRole()
		{
			string UserName = login.Text;

			string connStr = "server=localhost; port=3306; username=root; password=1234; database=korobkibd;";
			string sql = "SELECT PositionId FROM employees WHERE Login = @un";

			MySqlConnection conn = new MySqlConnection(connStr);
			conn.Open();

			MySqlParameter nameParam = new MySqlParameter("@un", UserName);

			MySqlCommand command = new MySqlCommand(sql, conn);
			command.Parameters.Add(nameParam);

			string Form_Role = command.ExecuteScalar().ToString();

			MenuForm main = new MenuForm();
			switch (Form_Role)
			{
				case "1":
					this.Hide();
					main.Show();
					break;
				default:
					this.Hide();
					main.Show();
					break;
			}
			conn.Close();
		}

		private void registr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{

		}
	}
}
