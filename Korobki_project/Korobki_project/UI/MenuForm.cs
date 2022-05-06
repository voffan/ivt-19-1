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
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            Context c = new Context();
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
            Context c = new Context();
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
                    employeeAddForm.FormClosed += f;
                    break;
                case 2:
                    PlanFromAdd planFromAdd = new PlanFromAdd();
                    planFromAdd.Show();
                    this.Hide();
                    planFromAdd.FormClosed += f;
                    break;
                case 3:
                    ProductionAddForm productionFormAdd = new ProductionAddForm();
                    productionFormAdd.Show();
                    this.Hide();
                    productionFormAdd.FormClosed += f;
                    break;
                case 4:
                    PositionsAddForm positionsAddForm = new PositionsAddForm();
                    positionsAddForm.Show();
                    this.Hide();
                    positionsAddForm.FormClosed += f;
                    break;
                case 5:
                    ProductAddForm productAddForm = new ProductAddForm();
                    productAddForm.Show();
                    this.Hide();
                    productAddForm.FormClosed += f;
                    break;
                case 6:
                    ScheduleFormAdd scheduleFormAdd = new ScheduleFormAdd();
                    scheduleFormAdd.Show();
                    this.Hide();
                    scheduleFormAdd.FormClosed += f;
                    break;
                case 7:
                    ShiftAddForm shiftFormAdd = new ShiftAddForm();
                    shiftFormAdd.Show();
                    this.Hide();
                    shiftFormAdd.FormClosed += f;
                    break;
                case 8:
                    TypeeFormAdd typeeFormAdd = new TypeeFormAdd();
                    typeeFormAdd.Show();
                    this.Hide();
                    typeeFormAdd.FormClosed += f;
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



        private void button10_Click_1(object sender, EventArgs e)
        {
            int index = id();
            if (index != -1)
            {
                switch (pf)
                {
                    case 1:
                        EmployeeEditForm employeeEdit = new EmployeeEditForm(index);
                        employeeEdit.Show();
                        this.Hide();
                        employeeEdit.FormClosed += f; // (object s, FormClosedEventArgs ev) => { this.Show(); };
                        break;
                    case 2:
                        PlanEditForm planEditForm = new PlanEditForm(index);
                        planEditForm.Show();
                        this.Hide();
                        planEditForm.FormClosed += f; // (object s, FormClosedEventArgs ev) => { this.Show(); };
                        break;
                    case 3:
                        ProductionEditForm productionEditForm = new ProductionEditForm(index);
                        productionEditForm.Show();
                        this.Hide();
                        productionEditForm.FormClosed += f; // (object s, FormClosedEventArgs ev) => { this.Show(); };
                        break;
                    case 4:
                        PositionEditForm positionEditForm = new PositionEditForm(index);
                        positionEditForm.Show();
                        this.Hide();
                        positionEditForm.FormClosed += f; // (object s, FormClosedEventArgs ev) => { this.Show(); };
                        break;
                    case 5:
                        ProductEditForm productEditForm = new ProductEditForm(index);
                        productEditForm.Show();
                        this.Hide();
                        productEditForm.FormClosed += f;
                        break;
                    case 6:
                        ScheduleEditForm scheduleEditForm = new ScheduleEditForm(index);
                        scheduleEditForm.Show();
                        this.Hide();
                        scheduleEditForm.FormClosed += f; // (object s, FormClosedEventArgs ev) => { this.Show(); };
                        break;
                    case 7:
                        ShiftEditForm shiftEditForm = new ShiftEditForm(index);
                        shiftEditForm.Show();
                        this.Hide();
                        shiftEditForm.FormClosed += f; // (object s, FormClosedEventArgs ev) => { this.Show(); };
                        break;
                    case 8:
                        TypeeEditForm typeeEditForm = new TypeeEditForm(index);
                        typeeEditForm.Show();
                        this.Hide();
                        typeeEditForm.FormClosed += f;
                        break;

                }
                load_db();
            }
        }

        private void f(object s, FormClosedEventArgs ev)
		{
            load_db();
            this.Show();
		}
        private void searchname()
        {
            using (Context context = new Context())
            {
                switch (pf)
                {
                    case 1:
                        dataGridView1.DataSource = EmployeeFunctions.Search(textBox1.Text);
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        dataGridView1.Columns[4].Visible = false;
                        dataGridView1.Columns[8].Visible = false;
                        break;
                    case 2:
                        dataGridView1.DataSource = PlanFunctions.Search(textBox1.Text);
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        break;
                    case 3:
                        dataGridView1.DataSource = ProductionFunctions.Search(textBox1.Text);
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        break;
                    case 4:
                        dataGridView1.DataSource = PositionFunctions.Search(textBox1.Text);
                        dataGridView1.Columns[0].Visible = false;
                        break;
                    case 5:
                        dataGridView1.DataSource = ProductFunctions.Search(textBox1.Text);
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        break;
                    case 6:
                        dataGridView1.DataSource = ScheduleFunctions.Search(textBox1.Text);
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        break;
                    case 7:
                        dataGridView1.DataSource = ShiftFunctions.Search(textBox1.Text);
                        dataGridView1.Columns[0].Visible = false;
                        break;
                    case 8:
                        dataGridView1.DataSource = TypeeFunctions.Search(textBox1.Text);
                        dataGridView1.Columns[0].Visible = false;
                        break;
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            searchname();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                searchname();
            }
        }
    }
}
