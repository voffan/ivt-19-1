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

namespace Korobki_project
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeForm eform = new EmployeeForm();
            eform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlanForm planform = new PlanForm();
            planform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductionForm productionForm = new ProductionForm();
            productionForm.Show();
        }
    }
}
