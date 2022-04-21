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
            using (Context c = new Context())
                dataGridView1.DataSource = c.Computers.ToList();
            label2.Text = "Текущий список: Компьютеры";
            /*
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            */
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
                    /*
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    */
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
                Form form_addComputer = new Form_addComputer(true, -1, this);
                form_addComputer.ShowDialog();
            }

            // Появление формы Form_addDepartment
            if (listBox1.SelectedIndex == 1) {
                Form form_addDepartment = new Form_addDepartment(true, -1, this);
                form_addDepartment.ShowDialog();
            }

            // Появление формы Form_addEmployee
            if (listBox1.SelectedIndex == 2) {
                Form form_addEmployee = new Form_addEmployee(true, -1, this);
                form_addEmployee.ShowDialog();
            }

            // Появление формы Form_addHDD
            if (listBox1.SelectedIndex == 3) {
                Form form_addHDD = new Form_addHDD(true, -1, this);
                
                form_addHDD.ShowDialog();
            }

            // Появление формы Form_addMotherboard
            if (listBox1.SelectedIndex == 4) {
                Form form_addMotherboard = new Form_addMotherboard(true, -1, this);
                form_addMotherboard.ShowDialog();
            }

            // Появление формы Form_addPeripheral
            if (listBox1.SelectedIndex == 5) {
                Form form_addPeripheral = new Form_addPeripheral(true, -1, this);
                form_addPeripheral.ShowDialog();
            }

            // Появление формы Form_addProcessor
            if (listBox1.SelectedIndex == 6) {
                Form form_addProcessor = new Form_addProcessor(true, -1, this);
                form_addProcessor.ShowDialog();
            }

            // Появление формы Form_addRAM
            if (listBox1.SelectedIndex == 7) { 
                Form form_addRAM = new Form_addRAM(true, -1, this);
                form_addRAM.ShowDialog();
            }

        }

        private void button3_Click(object sender, EventArgs e) //Edit button
        {
            if (dataGridView1.CurrentRow != null) {

                int index = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Id"].Value);

                if (listBox1.SelectedIndex == 0) {
                    Form form_addComputer = new Form_addComputer(false, index, this);
                    form_addComputer.ShowDialog();
                }

                // Появление формы Form_addDepartment
                if (listBox1.SelectedIndex == 1) {
                    Form form_addDepartment = new Form_addDepartment(false, index, this);
                    form_addDepartment.ShowDialog();
                }

                // Появление формы Form_addEmployee
                if (listBox1.SelectedIndex == 2) {
                    Form form_addEmployee = new Form_addEmployee(false, index, this);
                    form_addEmployee.ShowDialog();
                }

                // Появление формы Form_addHDD
                if (listBox1.SelectedIndex == 3) {
                    Form form_addHDD = new Form_addHDD(false, index, this);
                    form_addHDD.ShowDialog();
                }

                // Появление формы Form_addMotherboard
                if (listBox1.SelectedIndex == 4) {
                    Form form_addMotherboard = new Form_addMotherboard(false, index, this);
                    form_addMotherboard.ShowDialog();
                }

                // Появление формы Form_addPeripheral
                if (listBox1.SelectedIndex == 5) {
                    Form form_addPeripheral = new Form_addPeripheral(false, index, this);
                    form_addPeripheral.ShowDialog();
                }

                // Появление формы Form_addProcessor
                if (listBox1.SelectedIndex == 6) {
                    Form form_addProcessor = new Form_addProcessor(false, index, this);
                    form_addProcessor.ShowDialog();
                }

                // Появление формы Form_addRAM
                if (listBox1.SelectedIndex == 7) {
                    Form form_addRAM = new Form_addRAM(false, index, this);
                    form_addRAM.ShowDialog();
                }

            } else {
                MessageBox.Show("Элемент не выбран");
            }

        }

        private void button_Delete_Click(object sender, EventArgs e) {

            if (dataGridView1.CurrentRow != null) {
                int index = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Id"].Value);

                if (listBox1.SelectedIndex == 0) {

                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        ComputerFunctions computer = new ComputerFunctions();
                        computer.Delete(index);
                        Update_datagridview(0);
                    }
                }

                // Появление формы Form_addDepartment
                if (listBox1.SelectedIndex == 1) {

                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        DepartmentFunctions department = new DepartmentFunctions();
                        department.Delete(index);
                        Update_datagridview(1);
                    }
                }

                // Появление формы Form_addEmployee
                if (listBox1.SelectedIndex == 2) {

                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        EmployeeFunctions employee = new EmployeeFunctions();
                        employee.Delete(index);
                        Update_datagridview(2);
                    }
                }

                // Появление формы Form_addHDD
                if (listBox1.SelectedIndex == 3) {
                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        HDDFunctions hdd = new HDDFunctions();
                        hdd.Delete(index);
                        Update_datagridview(3);
                    }
                }

                // Появление формы Form_addMotherboard
                if (listBox1.SelectedIndex == 4) {

                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK)
                    {
                        MotherboardFunctions motherboard = new MotherboardFunctions();
                        motherboard.Delete(index);
                        Update_datagridview(4);
                    }
                }

                // Появление формы Form_addPeripheral
                if (listBox1.SelectedIndex == 5) {

                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        PeripheralFunctions peripheral = new PeripheralFunctions();
                        peripheral.Delete(index);
                        Update_datagridview(5);
                    }
                }

                // Появление формы Form_addProcessor
                if (listBox1.SelectedIndex == 6) {

                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK)
                    {
                        ProcessorFunctions processor = new ProcessorFunctions();
                        processor.Delete(index);
                        Update_datagridview(6);
                    }
                }

                // Появление формы Form_addRAM
                if (listBox1.SelectedIndex == 7) {

                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK)
                    {
                        RAMFunctions ram = new RAMFunctions();
                        ram.Delete(index);
                        Update_datagridview(7);
                    }
                }

            } else {
                MessageBox.Show("Элемент не выбран");
            }

        }

        public void Update_datagridview(int index) //Update datagridview when adding new record or editing record or deleting
       {
            switch (index) {
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
        }

        // Поиск в списках
        private void button4_Click(object sender, EventArgs e) { 

            using (Context context = new Context()) {

                /*
                if (listBox1.SelectedIndex == 0) {
                    // Query for all blogs with names starting with B
                    var search = context.Computers
                    .Where(b => b.Name.Contains(textBox1.Text))
                    .ToList();
                    dataGridView1.DataSource = search;
                }
                */

                //Поиск в списке департаментов по названию
                if (listBox1.SelectedIndex == 1) { 
                    var search = context.Departments
                    .Where(b => b.Name.Contains(textBox1.Text))
                    .ToList();
                    dataGridView1.DataSource = search;
                }

                //Поиск в списке сотрудников по фИО
                if (listBox1.SelectedIndex == 2) { 
                    var search = context.Employees
                    .Where(b => b.Name.Contains(textBox1.Text))
                    .ToList();
                    dataGridView1.DataSource = search;
                }

                //Поиск в списке жестких дисков по названию
                if (listBox1.SelectedIndex == 3) { 
                    var search = context.HDDs
                    .Where(b => b.Name.Contains(textBox1.Text))
                    .ToList();
                    dataGridView1.DataSource = search;
                }

                //Поиск в списке материнских плат по названию
                if (listBox1.SelectedIndex == 4) { 
                    var search = context.Motherboards
                    .Where(b => b.Name.Contains(textBox1.Text))
                    .ToList();
                    dataGridView1.DataSource = search;
                }

                //Поиск в списке периферийной технике по названию
                if (listBox1.SelectedIndex == 5) { 
                    var search = context.Peripherals
                    .Where(b => b.Name.Contains(textBox1.Text))
                    .ToList();
                    dataGridView1.DataSource = search;
                }

                //Поиск в списке процессоров по названию
                if (listBox1.SelectedIndex == 6) { 
                    var search = context.Processors
                    .Where(b => b.Name.Contains(textBox1.Text))
                    .ToList();
                    dataGridView1.DataSource = search;
                }

                //Поиск в списке оперативной памяти по названию
                if (listBox1.SelectedIndex == 7) {
                    var search = context.RAMs
                    .Where(b => b.Name.Contains(textBox1.Text))
                    .ToList();
                    dataGridView1.DataSource = search;
                }
            }
        }
    }
}
