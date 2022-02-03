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
	public partial class Form3 : System.Windows.Forms.Form
	{
		public Form3()
		{
			InitializeComponent();
		}


		/////////////////////////////////////


		private void Form3_Load(object sender, EventArgs e)
		{
			string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KOROBKI.accdb";
			OleDbConnection dbConnection = new OleDbConnection(connectionString);

			dbConnection.Open();
			string query = "select * from Boxes";
			OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
			OleDbDataReader dbReader = dbCommand.ExecuteReader();


			if (dbReader.HasRows == true)
			{
				while (dbReader.Read())
					dataGridView1.Rows.Add(dbReader["id"], dbReader["Type"]);
			}
			else
			{
				MessageBox.Show("ERROR");
			}
			dbReader.Close();
			dbConnection.Close();
		}


		/////////////////////////////////////


		private void назадToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
		}


		/////////////////////////////////////
		

		private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count != 1)
			{
				MessageBox.Show("Выберите одну строку", "Внимание");
				return;
			}
			int index = dataGridView1.SelectedRows[0].Index;
			for (int i = 0; i < 2; i++)
			{
				if (dataGridView1.Rows[index].Cells[i].Value == null)
				{
					MessageBox.Show("Не все данные введены", "Внимание");
					return;
				}
			}

			string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
			string Type = dataGridView1.Rows[index].Cells[1].Value.ToString();

			string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KOROBKI.accdb";
			OleDbConnection dbConnection = new OleDbConnection(connectionString);

			dbConnection.Open();
			string query = "INSERT INTO Boxes VALUES (" + id + ", '" + Type + "')";
			OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

			if (dbCommand.ExecuteNonQuery() != 1) MessageBox.Show("ERROR");
			else MessageBox.Show("Данные добавлены");

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
			string query = "DELETE FROM Boxes WHERE id = " + id;
			OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

			if (dbCommand.ExecuteNonQuery() != 1) MessageBox.Show("ERROR");
			else
			{
				MessageBox.Show("Данные удалены");
				dataGridView1.Rows.RemoveAt(index);
			}

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
			for (int i = 0; i < 2; i++)
			{
				if (dataGridView1.Rows[index].Cells[i].Value == null)
				{
					MessageBox.Show("Не все данные введены", "Внимание");
					return;
				}
			}

			string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
			string Type = dataGridView1.Rows[index].Cells[1].Value.ToString();

			string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KOROBKI.accdb";
			OleDbConnection dbConnection = new OleDbConnection(connectionString);

			dbConnection.Open();
			string query = "UPDATE Boxes SET Type = '" + Type + "' WHERE id = " + id;
			OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

			if (dbCommand.ExecuteNonQuery() != 1) MessageBox.Show("ERROR");
			else MessageBox.Show("Данные обновлены");

			dbConnection.Close();
		}
	}
}
