using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PROJECTKOROBKI
{
	public partial class Form4 : Form
	{
		public Form4()
		{
			InitializeComponent();
		}


		private void коробкиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form1 form1 = new Form1();
			form1.Show();
			this.Hide();
		}

		string Brigade;

		private void Form4_Load(object sender, EventArgs e)
		{
			this.Text = "Бригада 1";
			Brigade = "Brigade1";
			dataGridView1.Rows.Clear();
			string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KOROBKI.accdb";
			OleDbConnection dbConnection = new OleDbConnection(connectionString);

			dbConnection.Open();
			string query = "select * from Brigade1 order by id";
			OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
			OleDbDataReader dbReader = dbCommand.ExecuteReader();


			if (dbReader.HasRows == true)
			{
				while (dbReader.Read())
					dataGridView1.Rows.Add(dbReader["id"], dbReader["Fullname"], dbReader["hbday"], dbReader["Position"]);
			}
			else
			{
				MessageBox.Show("ERROR");
			}
			dbReader.Close();
			dbConnection.Close();
		}


		/////////////////////////////////////


		private void бригада1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Text = "Бригада 1";
			Brigade = "Brigade1";
			dataGridView1.Rows.Clear();
			string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KOROBKI.accdb";
			OleDbConnection dbConnection = new OleDbConnection(connectionString);

			dbConnection.Open();
			string query = "select * from Brigade1 order by id";
			OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
			OleDbDataReader dbReader = dbCommand.ExecuteReader();


			if (dbReader.HasRows == true)
			{
				while (dbReader.Read())
					dataGridView1.Rows.Add(dbReader["id"], dbReader["Fullname"], dbReader["hbday"], dbReader["Position"]);
			}
			else
			{
				MessageBox.Show("ERROR");
			}
			dbReader.Close();
			dbConnection.Close();
		}


		/////////////////////////////////////


		private void бригада2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Text = "Бригада 2";
			Brigade = "Brigade2";
			dataGridView1.Rows.Clear();
			string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KOROBKI.accdb";
			OleDbConnection dbConnection = new OleDbConnection(connectionString);

			dbConnection.Open();
			string query = "select * from Brigade2 order by id";
			OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
			OleDbDataReader dbReader = dbCommand.ExecuteReader();


			if (dbReader.HasRows == true)
			{
				while (dbReader.Read())
					dataGridView1.Rows.Add(dbReader["id"], dbReader["Fullname"], dbReader["hbday"], dbReader["Position"]);
			}
			else
			{
				MessageBox.Show("ERROR");
			}
			dbReader.Close();
			dbConnection.Close();
		}


		/////////////////////////////////////
		

		private void бригада3ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Text = "Бригада 3";
			Brigade = "Brigade3";
			dataGridView1.Rows.Clear();
			string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KOROBKI.accdb";
			OleDbConnection dbConnection = new OleDbConnection(connectionString);

			dbConnection.Open();
			string query = "select * from Brigade3 order by id";
			OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
			OleDbDataReader dbReader = dbCommand.ExecuteReader();


			if (dbReader.HasRows == true)
			{
				while (dbReader.Read())
					dataGridView1.Rows.Add(dbReader["id"], dbReader["Fullname"], dbReader["hbday"], dbReader["Position"]);
			}
			else
			{
				MessageBox.Show("ERROR");
			}
			dbReader.Close();
			dbConnection.Close();
		}



		//////////////////////////////////////////////////////////////////////////////////////


		private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count != 1)
			{
				MessageBox.Show("Выберите одну строку", "Внимание");
				return;
			}
			int index = dataGridView1.SelectedRows[0].Index;
			for (int i = 0; i < 4; i++)
			{
				if (dataGridView1.Rows[index].Cells[i].Value == null)
				{
					MessageBox.Show("Не все данные введены", "Внимание");
					return;
				}
			}

			string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
			string Fullname = dataGridView1.Rows[index].Cells[1].Value.ToString();
			string hbday = dataGridView1.Rows[index].Cells[2].Value.ToString();
			string Position = dataGridView1.Rows[index].Cells[3].Value.ToString();

			string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KOROBKI.accdb";
			OleDbConnection dbConnection = new OleDbConnection(connectionString);

			dbConnection.Open();

			
			string query = "INSERT INTO " + Brigade + " VALUES (" + id + ",  '" + Fullname + "', " + hbday + ", '" + Position + "')";
			OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

			if (dbCommand.ExecuteNonQuery() != 1) MessageBox.Show("ERROR");
			else MessageBox.Show("Данные добавлены");

			dbConnection.Close();
		}


		/////////////////////////////////////
		

		private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count != 1)
			{
				MessageBox.Show("Выберите одну строку", "Внимание");
				return;
			}
			int index = dataGridView1.SelectedRows[0].Index;
			for (int i = 0; i < 4; i++)
			{
				if (dataGridView1.Rows[index].Cells[i].Value == null)
				{
					MessageBox.Show("Не все данные введены", "Внимание");
					return;
				}
			}

			string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
			string Fullname = dataGridView1.Rows[index].Cells[1].Value.ToString();
			string hbday = dataGridView1.Rows[index].Cells[2].Value.ToString();
			string Position = dataGridView1.Rows[index].Cells[3].Value.ToString();

			string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KOROBKI.accdb";
			OleDbConnection dbConnection = new OleDbConnection(connectionString);

			dbConnection.Open();
			string query = "UPDATE " + Brigade + " SET Fullname = '" + Fullname + "', hbday = " + hbday + ", Position = '" + Position + "' WHERE id = " + id;
			OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

			if (dbCommand.ExecuteNonQuery() != 1) MessageBox.Show("ERROR");
			else MessageBox.Show("Данные обновлены");

			dbConnection.Close();
		}


		/////////////////////////////////////
		

		private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count != 1)
			{
				MessageBox.Show("Выберите одну строку", "Внимание");
				return;
			}
			int index = dataGridView1.SelectedRows[0].Index;
			if (dataGridView1.Rows[index].Cells[0].Value == null)
			{
				MessageBox.Show("Не все данные введены", "Внимание");
				return;
			}

			string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
			
			string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KOROBKI.accdb";
			OleDbConnection dbConnection = new OleDbConnection(connectionString);

			dbConnection.Open();

			string query = "DELETE FROM " + Brigade + " WHERE id = " + id;
			OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

			if (dbCommand.ExecuteNonQuery() != 1) MessageBox.Show("ERROR");
			else
			{
				MessageBox.Show("Данные удалены");
				dataGridView1.Rows.RemoveAt(index);
			}

			dbConnection.Close();
		}

		private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

	}
}
