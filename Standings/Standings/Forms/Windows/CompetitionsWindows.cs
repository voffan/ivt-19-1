using Standings.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Standings.Forms.Windows
{
    public partial class CompetitionsWindows : Form
    {
        public CompetitionsWindows()
        {
            InitializeComponent();
        }

        private void CompetitionsWindows_Load(object sender, EventArgs e)
        {
            InitTabl();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void InitTabl()
        {
            Context context = Connection.Connect();
            dataGridView1.DataSource = context.Competitions.ToList();
        }
    }
}
