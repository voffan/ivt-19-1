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
using Korobki_project.Classes;

namespace Korobki_project
{
    public partial class MenuForm : Form
    {
        private Form active;
        int pf = 1;
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
        private void MenuForm_Load(object sender, EventArgs e)
        {
            pf = 1;
            PanelForm(new EmployeeForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pf = 1;
            PanelForm(new EmployeeForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pf = 2;
            PanelForm(new PlanForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pf = 3;
            PanelForm(new ProductionForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pf = 4;
            PanelForm(new PositionForm());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pf = 5;
            PanelForm(new ProductForm());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pf = 6;
            PanelForm(new ScheduleForm());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pf = 7;
            PanelForm(new ShiftForm());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pf = 8;
            PanelForm(new TypeeForm());
        }

		private void btnadd_Click(object sender, EventArgs e)
		{
			switch (pf)
            {
                case 1:
                    EmployeeAddForm employeeAddForm = new EmployeeAddForm();
                    employeeAddForm.Show();
                    this.Hide();
                    break;
                case 2:
                    PlanFromAdd planFromAdd = new PlanFromAdd();
                    planFromAdd.Show();
                    this.Hide();
                    break;
                case 3:
					ProductionAddForm productionFormAdd = new ProductionAddForm();
					productionFormAdd.Show();
					this.Hide();
					break;
                case 4:
                    PositionsAddForm positionsAddForm = new PositionsAddForm();
                    positionsAddForm.Show();
                    this.Hide();
                    break;
                case 5:
                    ProductAddForm productAddForm = new ProductAddForm();
                    productAddForm.Show();
                    this.Hide();
                    break;
                    case 6:
                        ScheduleFormAdd scheduleFormAdd = new ScheduleFormAdd();
                        scheduleFormAdd.Show();
                        this.Hide();
                        break;
                    case 7:
                        ShiftAddForm shiftFormAdd = new ShiftAddForm();
                        shiftFormAdd.Show();
                        this.Hide();
                        break;
                    case 8:
                        TypeeFormAdd typeeFormAdd = new TypeeFormAdd();
                        typeeFormAdd.Show();
                        this.Hide();
                        break;
            }
        }

		private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
		{
            Application.Exit();
		}
	}
}
