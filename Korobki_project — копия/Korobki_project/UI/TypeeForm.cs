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
using Korobki_project.UI;
using Microsoft.EntityFrameworkCore;

namespace Korobki_project.UI
{
    public partial class TypeeForm : Form
    {
        public TypeeForm()
        {
            InitializeComponent();
            Context c = new Context();
            dataGridView1.DataSource = c.Typees.ToList();
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
