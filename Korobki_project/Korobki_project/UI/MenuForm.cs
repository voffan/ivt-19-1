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
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using Korobki_project.Functions;

namespace Korobki_project
{
    public partial class MenuForm : Form
    {
        int pf = 1;
        Context c = new Context();
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            pf = 1;
            dataGridView1.DataSource = c.Employees.Include("Position").Include("Shift").OrderBy(e => e.Name).ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[8].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pf = 1;
            load_db();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pf = 2;
            load_db();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pf = 3;
            load_db();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pf = 4;
            load_db();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pf = 5;
            load_db();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pf = 6;
            load_db();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pf = 7;
            load_db();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pf = 8;
            load_db();
        }

        private void load_db()
		{
            switch (pf)
			{
                case 1:
                    dataGridView1.DataSource = c.Employees.Include("Position").Include("Shift").OrderBy(e => e.Name).ToList();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    break;
                case 2:
                    dataGridView1.DataSource = c.Plans.Include("Product").ToList();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    break;
                case 3:
                    dataGridView1.DataSource = c.Productions.Include("Team").Include("Product").ToList();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    break;
                case 4:
                    dataGridView1.DataSource = c.Positions.ToList();
                    dataGridView1.Columns[0].Visible = false;
                    break;
                case 5:
                    dataGridView1.DataSource = c.Products.Include("Typee").ToList();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    break;
                case 6:
                    dataGridView1.DataSource = c.Schedules.Include("Shift").ToList();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    break;
                case 7:
                    dataGridView1.DataSource = c.Shifts.ToList();
                    dataGridView1.Columns[0].Visible = false;
                    break;
                case 8:
                    dataGridView1.DataSource = c.Typees.ToList();
                    dataGridView1.Columns[0].Visible = false;
                    break;
            }
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

        private int id()
        {
            int a, b;
            if (dataGridView1.SelectedRows != null)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    b = dataGridView1.CurrentRow.Index;
                    a = Convert.ToInt32(dataGridView1.Rows[b].Cells[0].Value);
                    return a;
                }
                else
                {
                    MessageBox.Show("Строка не выбрана!");
                }
            }
            return -1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Действительно удалить запись в БД?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int index = id();
                if(dataGridView1.CurrentRow != null)
				{
                    switch (pf)
                    {
                        case 1:
                            EmployeeFunctions ef = new EmployeeFunctions();
                            ef.Delete(index);
                            break;
                        case 2:
                            PlanFunctions plf = new PlanFunctions();
                            plf.Delete(index);
                            break;
                        case 3:
                            ProductionFunctions prd = new ProductionFunctions();
                            prd.Delete(index);
                            break;
                        case 4:
                            PositionFunctions pst = new PositionFunctions();
                            pst.Delete(index);
                            break;
                        case 5:
                            ProductFunctions pr = new ProductFunctions();
                            pr.Delete(index);
                            break;
                        case 6:
                            ScheduleFunctions sch = new ScheduleFunctions();
                            sch.Delete(index);
                            break;
                        case 7:
                            ShiftFunctions sh = new ShiftFunctions();
                            sh.Delete(index);
                            break;
                        case 8:
                            TypeeFunctions tp = new TypeeFunctions();
                            tp.Delete(index);
                            break;
                    }
                    load_db();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int index = id();
            if (index != -1)
            {
                switch (pf)
                {
                    case 1:
                        EmployeeEditForm employeeEditForm = EmployeeEditForm();
                        employeeEditForm.Show();
                        this.Hide();
                        break;

                }
            }
        }
    }
}
