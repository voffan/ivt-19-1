using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PROJECTKOROBKI
{
	public partial class Form2 : System.Windows.Forms.Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		private void коробкиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form1 form1 = new Form1();
			form1.Show();
			this.Hide();
		}


		/////////////////////////////////////


		private void Form2_Load(object sender, EventArgs e)
		{
			string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KOROBKI.accdb";
			OleDbConnection dbConnection = new OleDbConnection(connectionString);

			dbConnection.Open();
			string query = "select * from Report order by id";
			OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
			OleDbDataReader dbReader = dbCommand.ExecuteReader();

			if (dbReader.HasRows == true)
			{
				while (dbReader.Read())
				{
					dataGridView1.Rows.Add(dbReader["id"], dbReader["Boxes"], dbReader["Dimensions"], dbReader["Amount"]);	
				}

			}
			else
			{
				MessageBox.Show("ERROR");
			}
			dbReader.Close();
			dbConnection.Close();
		}


		/////////////////////////////////////


		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}



		/////////////////////////////////////


		private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(dataGridView1.SelectedRows.Count != 1)
			{
				MessageBox.Show("Выберите одну строку", "Внимание");
				return;
			}
			int index = dataGridView1.SelectedRows[0].Index;
			for(int i = 0; i < 4; i++)
			{
				if (dataGridView1.Rows[index].Cells[i].Value == null)
				{
					MessageBox.Show("Не все данные введены", "Внимание");
					return;
				}
			}

			string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
			string Boxes = dataGridView1.Rows[index].Cells[1].Value.ToString();
			string Dimensions = dataGridView1.Rows[index].Cells[2].Value.ToString();
			string Amount = dataGridView1.Rows[index].Cells[3].Value.ToString();

			string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KOROBKI.accdb";
			OleDbConnection dbConnection = new OleDbConnection(connectionString);

			dbConnection.Open();
			string query = "INSERT INTO Report VALUES (" + id + ", '" + Boxes + "', '" + Dimensions + "', " + Amount + ")";
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
			string Boxes = dataGridView1.Rows[index].Cells[1].Value.ToString();
			string Dimensions = dataGridView1.Rows[index].Cells[2].Value.ToString();
			string Amount = dataGridView1.Rows[index].Cells[3].Value.ToString();

			string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KOROBKI.accdb";
			OleDbConnection dbConnection = new OleDbConnection(connectionString);

			dbConnection.Open();
			string query = "UPDATE Report SET Boxes = '" + Boxes + "', Dimensions = '" + Dimensions + "', Amount = " + Amount + " WHERE id = " + id;
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
			string query = "DELETE FROM Report WHERE id = " + id;
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


		private void обКоробкахToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form3 form3 = new Form3();
			form3.Show();
		}
	}
}
