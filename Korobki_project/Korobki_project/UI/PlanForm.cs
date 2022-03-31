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

namespace Korobki_project
{
    public partial class PlanForm : Form
    {
        public PlanForm()
        {
            InitializeComponent();
            Context c = new Context();
            dataGridView1.DataSource = c.Plans.Include("Product").ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
        }

        private void PlanFromAddButton_Click(object sender, EventArgs e)
        {

        }
    }
}
