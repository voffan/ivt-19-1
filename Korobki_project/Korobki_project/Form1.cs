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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Context c = new Context();
            dataGridView1.DataSource = c.Employees.Include("Position").ToList();

        }

    }
}
