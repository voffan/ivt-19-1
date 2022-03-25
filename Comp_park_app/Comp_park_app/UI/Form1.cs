using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comp_park_app;
using Comp_park_app.UI;
using Comp_park_app.Functions;

namespace Comp_park_app_form {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Context c = new Context();
            dataGridView1.DataSource = c.Computers.ToList();
            /*dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;*/
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);

            ExitCheck exit = new ExitCheck();
            if (exit.ShowDialog() == DialogResult.OK) {
                //Application.Exit();
            } else {
                e.Cancel = true;
            }
        }

        //Переключение между списками
        private void button1_Click(object sender, EventArgs e) {
            switch (listBox1.SelectedIndex) {
                case 0: //Computers
                    Context c0 = new Context();
                    dataGridView1.DataSource = c0.Computers.ToList();
                    /*dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;*/
                    break;
                case 1: //Departments
                    Context c1 = new Context();
                    dataGridView1.DataSource = c1.Departments.ToList();
                    break;
                case 2: //Employees
                    Context c2 = new Context();
                    dataGridView1.DataSource = c2.Employees.ToList();
                    break;
                case 3: //HDDs
                    Context c3 = new Context();
                    dataGridView1.DataSource = c3.HDDs.ToList();
                    break;
                case 4: //Motherboards
                    Context c4 = new Context();
                    dataGridView1.DataSource = c4.Motherboards.ToList();
                    break;
                case 5: //Peripherals
                    Context c5 = new Context();
                    dataGridView1.DataSource = c5.Peripherals.ToList();
                    break;
                case 6: //Processors
                    Context c6 = new Context();
                    dataGridView1.DataSource = c6.Processors.ToList();
                    break;
                case 7: //RAMs
                    Context c7 = new Context();
                    dataGridView1.DataSource = c7.RAMs.ToList();
                    break;
            }
            label2.Text = "Текущий список: " + listBox1.SelectedItem.ToString();
        }

        // Формы добавления
        private void button2_Click(object sender, EventArgs e) { //Add button

            // Появление формы Form_addComputer
            if (listBox1.SelectedIndex == 0) {
                Form form_addComputer = new Form_addComputer(true);
                form_addComputer.ShowDialog();
            }

            // Появление формы Form_addDepartment
            if (listBox1.SelectedIndex == 1) {
                Form form_addDepartment = new Form_addDepartment(true);
                form_addDepartment.ShowDialog();
            }

            // Появление формы Form_addEmployee
            if (listBox1.SelectedIndex == 2) {
                Form form_addEmployee = new Form_addEmployee(true);
                form_addEmployee.ShowDialog();
            }

            // Появление формы Form_addHDD
            if (listBox1.SelectedIndex == 3) {
                Form form_addHDD = new Form_addHDD(true);
                form_addHDD.ShowDialog();
            }

            // Появление формы Form_addMotherboard
            if (listBox1.SelectedIndex == 4) {
                Form form_addMotherboard = new Form_addMotherboard(true);
                form_addMotherboard.ShowDialog();
            }

            // Появление формы Form_addPeripheral
            if (listBox1.SelectedIndex == 5) {
                Form form_addPeripheral = new Form_addPeripheral(true);
                form_addPeripheral.ShowDialog();
            }

            // Появление формы Form_addProcessor
            if (listBox1.SelectedIndex == 6) {
                Form form_addProcessor = new Form_addProcessor(true);
                form_addProcessor.ShowDialog();
            }

            // Появление формы Form_addRAM
            if (listBox1.SelectedIndex == 7) { 
                Form form_addRAM = new Form_addRAM(true, -1);
                form_addRAM.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e) //Edit button
        {
            if (listBox1.SelectedIndex == 0)
            {
                Form form_addComputer = new Form_addComputer(false);
                form_addComputer.ShowDialog();
            }

            // Появление формы Form_addDepartment
            if (listBox1.SelectedIndex == 1)
            {
                Form form_addDepartment = new Form_addDepartment(false);
                form_addDepartment.ShowDialog();
            }

            // Появление формы Form_addEmployee
            if (listBox1.SelectedIndex == 2)
            {
                Form form_addEmployee = new Form_addEmployee(false);
                form_addEmployee.ShowDialog();
            }

            // Появление формы Form_addHDD
            if (listBox1.SelectedIndex == 3)
            {
                Form form_addHDD = new Form_addHDD(false);
                form_addHDD.ShowDialog();
            }

            // Появление формы Form_addMotherboard
            if (listBox1.SelectedIndex == 4)
            {
                Form form_addMotherboard = new Form_addMotherboard(false);
                form_addMotherboard.ShowDialog();
            }

            // Появление формы Form_addPeripheral
            if (listBox1.SelectedIndex == 5)
            {
                Form form_addPeripheral = new Form_addPeripheral(false);
                form_addPeripheral.ShowDialog();
            }

            // Появление формы Form_addProcessor
            if (listBox1.SelectedIndex == 6)
            {
                Form form_addProcessor = new Form_addProcessor(false);
                form_addProcessor.ShowDialog();
            }

            // Появление формы Form_addRAM
            if (listBox1.SelectedIndex == 7)
            {
                Form form_addRAM = new Form_addRAM(false, Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Id"].Value));
                form_addRAM.ShowDialog();
            }
        }
    }
}
