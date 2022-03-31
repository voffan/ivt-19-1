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
            Context context = Connection.Connect();
            dataGridView1.DataSource = context.Employees.ToList();
        }

    }
}
