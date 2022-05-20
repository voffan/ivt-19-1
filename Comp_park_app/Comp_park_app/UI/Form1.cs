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
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;

namespace Comp_park_app_form {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            using (Context c = new Context()) {
                dataGridView1.DataSource = c.Computers.Include(x => x.Department).Include(z => z.Employee).ToList();
            }
            dataGridView1.Columns[9].Visible = false; //Столбец номера материнской платы
            dataGridView1.Columns[10].Visible = false; //Столбец материнской платы
            label2.Text = "Текущий список: Компьютеры";
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
                    using (Context c0 = new Context()) {
                        dataGridView1.DataSource = c0.Computers.Include(x => x.Department).Include(z => z.Employee).ToList();
                    }
                    dataGridView1.Columns[2].Visible = true;
                    dataGridView1.Columns[9].Visible = false; //Столбец номера материнской платы
                    dataGridView1.Columns[10].Visible = false; //Столбец материнской платы
                    break;
                case 1: //Departments
                    Context c1 = new Context();
                    dataGridView1.DataSource = c1.Departments.ToList();
                    dataGridView1.Columns[2].Visible = true;
                    break;
                case 2: //Employees
                    Context c2 = new Context();
                    dataGridView1.DataSource = c2.Employees.Include(x => x.Department).Include(y => y.Position).ToList();
                    dataGridView1.Columns[2].Visible = false; // Столбец пароля
                    break;
                case 3: //HDDs
                    Context c3 = new Context();
                    dataGridView1.DataSource = c3.HDDs.ToList();
                    dataGridView1.Columns[2].Visible = true;
                    break;
                case 4: //Motherboards
                    Context c4 = new Context();
                    dataGridView1.DataSource = c4.Motherboards.ToList();
                    dataGridView1.Columns[2].Visible = true;
                    break;
                case 5: //Peripherals
                    Context c5 = new Context();
                    dataGridView1.DataSource = c5.Peripherals.Include(x => x.Employee).Include(y => y.Department).ToList();
                    dataGridView1.Columns[2].Visible = true;
                    break;
                case 6: //Processors
                    Context c6 = new Context();
                    dataGridView1.DataSource = c6.Processors.ToList();
                    dataGridView1.Columns[2].Visible = true;
                    break;
                case 7: //RAMs
                    Context c7 = new Context();
                    dataGridView1.DataSource = c7.RAMs.ToList();
                    dataGridView1.Columns[2].Visible = true;
                    break;
                case 8: //Positions
                    Context c8 = new Context();
                    dataGridView1.DataSource = c8.Positions.ToList();
                    break;
            }
            label2.Text = "Текущий список: " + listBox1.SelectedItem.ToString();
        }

        // Формы добавления
        private void button2_Click(object sender, EventArgs e) {

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

            // Появление формы Form_addPosition
            if (listBox1.SelectedIndex == 8) {
                Form form_addPosition = new Form_addPosition(true, -1, this);
                form_addPosition.ShowDialog();
            }

        }

        //Edit button
        private void button3_Click(object sender, EventArgs e)  {
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

                // Появление формы Form_addPosition
                if (listBox1.SelectedIndex == 8)
                {
                    Form form_addPosition = new Form_addPosition(false, index, this);
                    form_addPosition.ShowDialog();
                }

            } else {
                MessageBox.Show("Элемент не выбран");
            }

        }

        //Delete button
        private void button_Delete_Click(object sender, EventArgs e) {

            if (dataGridView1.CurrentRow != null) {
                int index = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Id"].Value);

                // Появление формы удаления компьютера
                if (listBox1.SelectedIndex == 0) {
                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        ComputerFunctions computer = new ComputerFunctions();
                        computer.Delete(index);
                        Update_datagridview(0);
                    }
                }

                // Появление формы удаления департамента
                if (listBox1.SelectedIndex == 1) {
                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        DepartmentFunctions department = new DepartmentFunctions();
                        department.Delete(index);
                        Update_datagridview(1);
                    }
                }

                // Появление формы удаления сотрудника
                if (listBox1.SelectedIndex == 2) {
                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        EmployeeFunctions employee = new EmployeeFunctions();
                        employee.Delete(index);
                        Update_datagridview(2);
                    }
                }

                // Появление формы удаления жесткого диска
                if (listBox1.SelectedIndex == 3) {
                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        HDDFunctions hdd = new HDDFunctions();
                        hdd.Delete(index);
                        Update_datagridview(3);
                    }
                }

                // Появление формы удаления материнской платы
                if (listBox1.SelectedIndex == 4) {
                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        MotherboardFunctions motherboard = new MotherboardFunctions();
                        motherboard.Delete(index);
                        Update_datagridview(4);
                    }
                }

                // Появление формы удаления периферийной техники
                if (listBox1.SelectedIndex == 5) {
                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        PeripheralFunctions peripheral = new PeripheralFunctions();
                        peripheral.Delete(index);
                        Update_datagridview(5);
                    }
                }

                // Появление формы удаления процессора
                if (listBox1.SelectedIndex == 6) {
                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        ProcessorFunctions processor = new ProcessorFunctions();
                        processor.Delete(index);
                        Update_datagridview(6);
                    }
                }

                // Появление формы удаления оперативной памяти
                if (listBox1.SelectedIndex == 7) {
                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        RAMFunctions ram = new RAMFunctions();
                        ram.Delete(index);
                        Update_datagridview(7);
                    }
                }

                // Появление формы удаления должности
                if (listBox1.SelectedIndex == 8) {
                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        PositionFunctions pos = new PositionFunctions();
                        pos.Delete(index);
                        Update_datagridview(8);
                    }
                }

            } else {
                MessageBox.Show("Элемент не выбран");
            }

        }

        //Update datagridview when adding new record or editing record or deleting
        public void Update_datagridview(int index) { 
            switch (index) {
                case 0: //Computers
                    Context c0 = new Context();
                    dataGridView1.DataSource = c0.Computers.Include(x => x.Department).Include(z => z.Employee).ToList();
                    break;
                case 1: //Departments
                    Context c1 = new Context();
                    dataGridView1.DataSource = c1.Departments.ToList();
                    break;
                case 2: //Employees
                    Context c2 = new Context();
                    dataGridView1.DataSource = c2.Employees.Include(x => x.Department).Include(y => y.Position).ToList();
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
                    dataGridView1.DataSource = c5.Peripherals.Include(x => x.Employee).Include(y => y.Department).ToList();
                    break;
                case 6: //Processors
                    Context c6 = new Context();
                    dataGridView1.DataSource = c6.Processors.ToList();
                    break;
                case 7: //RAMs
                    Context c7 = new Context();
                    dataGridView1.DataSource = c7.RAMs.ToList();
                    break;
                case 8: //Positions
                    Context c8 = new Context();
                    dataGridView1.DataSource = c8.Positions.ToList();
                    break;
            }
        }

        // Поиск в списках
        private void button4_Click(object sender, EventArgs e) {
            using (Context context = new Context()) {

                //Поиск в списке компьютеров по названию
                if (listBox1.SelectedIndex == 0) {
                    dataGridView1.DataSource = ComputerFunctions.Search(textBox1.Text);
                }

                //Поиск в списке департаментов по названию
                if (listBox1.SelectedIndex == 1) {
                    dataGridView1.DataSource = DepartmentFunctions.Search(textBox1.Text);
                }

                //Поиск в списке сотрудников по фИО
                if (listBox1.SelectedIndex == 2) {
                    dataGridView1.DataSource = EmployeeFunctions.Search(textBox1.Text);
                }

                //Поиск в списке жестких дисков по названию
                if (listBox1.SelectedIndex == 3) {
                    dataGridView1.DataSource = HDDFunctions.Search(textBox1.Text);
                }

                //Поиск в списке материнских плат по названию
                if (listBox1.SelectedIndex == 4) {
                    dataGridView1.DataSource = MotherboardFunctions.Search(textBox1.Text);
                }

                //Поиск в списке периферийной технике по названию
                if (listBox1.SelectedIndex == 5) {
                    dataGridView1.DataSource = PeripheralFunctions.Search(textBox1.Text);
                }

                //Поиск в списке процессоров по названию
                if (listBox1.SelectedIndex == 6) {
                    dataGridView1.DataSource = ProcessorFunctions.Search(textBox1.Text);
                }

                //Поиск в списке оперативной памяти по названию
                if (listBox1.SelectedIndex == 7) {
                    dataGridView1.DataSource = HDDFunctions.Search(textBox1.Text);
                }

                //Поиск в списке должностей по названию
                if (listBox1.SelectedIndex == 8) {
                    dataGridView1.DataSource = PositionFunctions.Search(textBox1.Text);
                }
            }
        }

        //Появление формы отчетов
        private void buttonReport_Click(object sender, EventArgs e) {
            Form_reports report = new Form_reports();
            report.ShowDialog();
        }
    }
}