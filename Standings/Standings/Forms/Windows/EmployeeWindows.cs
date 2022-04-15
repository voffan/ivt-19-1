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
        Action<int> currentDeleteAction;
        List<Button> currentlyPermittedActions = new List<Button>();
        DataGridViewCellEventHandler tableItemDoubleClickEvent;
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

        private void button3_Click(object sender, EventArgs e)
        {
            
            currentDeleteAction = Connection.employeeFunctions.Delete;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                currentDeleteAction((int)row.Cells["Id"].Value);
            }
            InitTabl();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!currentlyPermittedActions.Contains(button3))
                return;

            if (dataGridView1.SelectedRows.Count == 0)
                button3.Enabled = false;
            else
                button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateEmployee AE = new UpdateEmployee();
            AE.ShowDialog();
            InitTabl();
        }
    }
}
