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
    public partial class SportsmansWindows : Form
    {
        public SportsmansWindows()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void InitTabl()
        {
            Context context = Connection.Connect();
            dataGridView1.DataSource = context.Sportsmans.ToList();
        }

        private void SportsmansWindows_Load(object sender, EventArgs e)
        {
            InitTabl();
        }
    }
}
