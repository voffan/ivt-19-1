using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Standings.Database;
using Standings.Functions;

namespace Standings.Forms
{
    public partial class EmployeeWindows : Form
    {
        
        public EmployeeWindows()
        {
            InitializeComponent();
        }
        private void EmployeeWindows_Load(object sender, EventArgs e)
        {
            InitTabl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployee AE = new AddEmployee();
            AE.ShowDialog();
            InitTabl();
        }

        private void InitTabl()
        {
            Context context = Connection.Connect();
            dataGridView1.DataSource = context.Employees.ToList();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!currentlyPermittedActions.Contains(deleteBtn))
                return;

            if (dataGridView.SelectedRows.Count == 0)
                deleteBtn.Enabled = false;
            else
                deleteBtn.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                currentDeleteAction((int)row.Cells["Id"].Value);
            }

            reloadBtn.PerformClick();
        }
    }
}
