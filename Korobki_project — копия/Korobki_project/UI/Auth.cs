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
			dataGridView1.DataSource = c.Employees.Include("Position").Include("Shift").ToList();

		}

		private void registr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{

		}
	}
}
