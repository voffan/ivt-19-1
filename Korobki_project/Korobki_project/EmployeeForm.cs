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


namespace Korobki_project
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
            Context c = new Context();
         /*  dataGridView1.DataSource = c.Employees.Join(c.Shifts, e => e.ShiftId, s => s.Id, (e, s) => new
            {
                Id = e.Id,
                Name = e.Name,
                PositionId = e.PositionId,
                Position = e.Position,
                PhoneNumber = e.PhoneNumber,
                Adress = e.Adress,
                Shift = s.Name
            }).Join(c.Positions, e => e.PositionId, p => p.Id, (e, p) => new
            {
                Id = e.Id,
                Name = e.Name,
                Position = p.Name,
                PhoneNumber = e.PhoneNumber,
                Adress = e.Adress,
                Shift = e.Shift
            }).ToList();*/
            dataGridView1.DataSource = c.Employees.Include("Position").Include("Shift").ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[8].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlanForm planForm = new PlanForm();
            planForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm main = new MenuForm();
            main.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductionForm productionForm = new ProductionForm();
            productionForm.Show();
        }
    }
}
