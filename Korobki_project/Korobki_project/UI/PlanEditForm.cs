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
using Korobki_project;

namespace Korobki_project.UI
{
    public partial class PlanEditForm : Form
    {
        int id;
        public PlanEditForm(int index)
        {
            InitializeComponent();
            id = index;
        }

        private void PlanEditForm_Load(object sender, EventArgs e)
        {
            Plan plan;
            using (Context c = new Context())
            {
                plan = c.Plans.Find(id);
                textBox1.Text = plan.Count_box.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(plan.PlanDate);
                comboBox1.DataSource = (new Context()).Products.ToList();
                comboBox1.DisplayMember = "Size_box";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedItem = c.Products.Find(plan.ProductId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && comboBox1.SelectedIndex>=0)
            {
                PlanFunctions plan = new PlanFunctions();
                var count_box = Convert.ToInt32(textBox1.Text);
                var datetime = dateTimePicker1.Value.ToString("dd.MM.yyyy");
                var productid = Convert.ToInt32(comboBox1.SelectedValue);
                plan.Edit(id, count_box, datetime, productid);
                this.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
