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
	public partial class ProductionEditForm : Form
	{
		int id;
		public ProductionEditForm(int index)
		{
            InitializeComponent();
			id = index;
		}

		private void button1_Click(object sender, EventArgs e)
		{
            if (textBox1.TextLength != 0 && textBox2.TextLength != 0 && comboBox1.SelectedIndex >= 0 && comboBox2.SelectedIndex >= 0)
            {
                ProductionFunctions production = new ProductionFunctions();
                var count =Convert.ToInt32(textBox1.Text);
                var comment = textBox2.Text;
                var teamid = Convert.ToInt32(comboBox1.SelectedValue);
                var productid = Convert.ToInt32(comboBox2.SelectedValue);
                production.Edit(id, teamid, productid, count, comment);
                this.Close();
            }
        }

		private void ProductionEditForm_Load(object sender, EventArgs e)
		{
            Production prod;
            using (Context c = new Context())
            {
                prod = c.Productions.Find(id);
                textBox1.Text = prod.Count.ToString();
                textBox2.Text = prod.Comment;


                comboBox1.DataSource = c.Schedules.ToList();
                comboBox1.DisplayMember = "Date";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedItem = c.Schedules.Find(prod.TeamId);

                comboBox2.DataSource = c.Products.ToList();
                comboBox2.DisplayMember = "Size_box";
                comboBox2.ValueMember = "Id";
                comboBox2.SelectedItem = c.Products.Find(prod.ProductId);
            }
        }
	}
}
