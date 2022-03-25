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

namespace Korobki_project
{
    public partial class MenuForm : Form
    {
        private Form active;
        public MenuForm()
        {
            InitializeComponent();
        }
        private void PanelForm(Form fm)
        {
            if (active!=null)
            {
                active.Close();
            }
            active = fm;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fm);
            this.panel1.Tag = fm;
            fm.BringToFront();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelForm(new EmployeeForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelForm(new PlanForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PanelForm(new ProductionForm());
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            PanelForm(new EmployeeForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PanelForm(new PositionForm());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PanelForm(new ProductForm());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PanelForm(new ScheduleForm());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PanelForm(new ShiftForm());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PanelForm(new TypeeForm());
        }
    }
}
