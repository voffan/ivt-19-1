using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Korobki_project.Classes;
using Korobki_project.Functions;

namespace Korobki_project.UI
{
	public partial class PositionEditForm : Form
	{
		int id;
		public PositionEditForm(int index)
		{
			InitializeComponent();
			id = index;
		}

		private void PositionEditForm_Load(object sender, EventArgs e)
		{
			Position pos;
			using (Context c = new Context())
			{
				pos = c.Positions.Find(id);
				textBox1.Text = pos.Name;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text.Length!=0)
			{
				PositionFunctions position = new PositionFunctions();
				var name = textBox1.Text;
				position.Edit(id, name);
				this.Close();

			}
		}
	}
}
