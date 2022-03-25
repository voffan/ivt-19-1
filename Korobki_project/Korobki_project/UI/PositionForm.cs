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
using Korobki_project.UI;

namespace Korobki_project.UI
{
    public partial class PositionForm : Form
    {
        public PositionForm()
        {
            InitializeComponent();
            Context c = new Context();
            dataGridView1.DataSource = c.Positions.ToList();
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
