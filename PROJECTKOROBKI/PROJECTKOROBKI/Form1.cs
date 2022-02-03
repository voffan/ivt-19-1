using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECTKOROBKI
{
	public partial class Form1 : System.Windows.Forms.Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void отчётToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 form2 = new Form2();
			form2.Show();
			this.Hide();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form4 form4 = new Form4();
			form4.Show();
			this.Hide();
		}
	}
}
