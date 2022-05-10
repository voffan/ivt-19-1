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

                // Появление формы Form_addComputer
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
                    if (del.ShowDialog() == DialogResult.OK) {
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
                    if (del.ShowDialog() == DialogResult.OK) {
                        ProcessorFunctions processor = new ProcessorFunctions();
                        processor.Delete(index);
                        Update_datagridview(6);
                    }
                }

                // Появление формы Form_addRAM
                if (listBox1.SelectedIndex == 7) {
                    DeleteCheck del = new DeleteCheck();
                    if (del.ShowDialog() == DialogResult.OK) {
                        RAMFunctions ram = new RAMFunctions();
                        ram.Delete(index);
                        Update_datagridview(7);
                    }
                }

                // Появление формы Form_addRAM
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

        //Формирование отчета
        private void buttonReport_Click(object sender, EventArgs e) {
            DialogResult res = MessageBox.Show("Экспорт завершен. При нажатии Yes будет предложено сохранить файл, " +
                "при нажатии No будет предложена отмена сохранения.", "Экспорт в Excel", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes) {

                int countRepair = 0, countRemoved = 0;
                DateTime nowTime = new DateTime();
                nowTime = DateTime.Now;

                Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = Excel.Workbooks.Add(System.Reflection.Missing.Value);

                Worksheet worksheet1 = wb.Sheets[1];
                worksheet1.Activate();
                worksheet1.Cells[1, 3] = "Компьютеры на ремонте";
                worksheet1.Cells[2, 1] = "Инвентарный номер";
                worksheet1.Cells[2, 2] = "Отдел";
                worksheet1.Cells[2, 3] = "Сотрудник";
                worksheet1.Cells[2, 4] = "Причина";

                Worksheet worksheet2 = wb.Worksheets.Add();
                worksheet2.Activate();
                worksheet2.Cells[1, 3] = "Периферийная техника на ремонте";
                worksheet2.Cells[2, 1] = "Инвентарный номер";
                worksheet2.Cells[2, 2] = "Название";
                worksheet2.Cells[2, 3] = "Отдел";
                worksheet2.Cells[2, 4] = "Сотрудник";
                worksheet2.Cells[2, 5] = "Причина";



                using (Context c = new Context()) {

                    //Computers
                    foreach (var i in c.Computers.Include(x => x.Department).Include(z => z.Employee)) {
                        if (i.Status == Status.InRepair && nowTime.Month == i.Date.Month) {
                            worksheet1.Cells[countRepair + 3, 1] = i.ItemNo;
                            worksheet1.Cells[countRepair + 3, 2] = i.Department;
                            worksheet1.Cells[countRepair + 3, 3] = i.Employee;
                            worksheet1.Cells[countRepair + 3, 4] = i.Reason;

                            //worksheet1.Cells[countRepair + 3, 5] = i.Date.Month;
                            //worksheet1.Cells[countRepair + 3, 6] = nowTime.Month;
                            countRepair++;
                        }

                        worksheet1.Cells[countRepair + countRemoved + 4, 3] = "Списанные компьютеры";

                        if (i.Status == Status.Removed && nowTime.Month == i.Date.Month) {
                            worksheet1.Cells[countRepair + countRemoved + 5, 1] = i.ItemNo;
                            worksheet1.Cells[countRepair + countRemoved + 5, 2] = i.Department;
                            worksheet1.Cells[countRepair + countRemoved + 5, 3] = i.Employee;
                            worksheet1.Cells[countRepair + countRemoved + 5, 4] = i.Reason;

                            //worksheet1.Cells[countRepair + countRemoved + 5, 5] = i.Date.Month;
                            //worksheet1.Cells[countRepair + countRemoved + 5, 6] = nowTime.Month;
                            countRemoved++;
                        }
                    }

                    countRepair = 0; countRemoved = 0;
                    //Peripheral
                    foreach (var i in c.Peripherals.Include(x => x.Employee).Include(y => y.Department)) {
                        if (i.Status == Status.InRepair && nowTime.Month == i.Date.Month) {
                            worksheet2.Cells[countRepair + 3, 1] = i.ItemNo;
                            worksheet2.Cells[countRepair + 3, 2] = i.Name;
                            worksheet2.Cells[countRepair + 3, 3] = i.Department;
                            worksheet2.Cells[countRepair + 3, 4] = i.Employee;
                            worksheet2.Cells[countRepair + 3, 5] = i.Reason;
                            countRepair++;
                        }

                        worksheet2.Cells[countRepair + countRemoved + 4, 3] = "Списанная периферийная техника";

                        if (i.Status == Status.Removed && nowTime.Month == i.Date.Month) {
                            worksheet2.Cells[countRepair + countRemoved + 5, 1] = i.ItemNo;
                            worksheet2.Cells[countRepair + countRemoved + 5, 2] = i.Name;
                            worksheet2.Cells[countRepair + countRemoved + 5, 3] = i.Department;
                            worksheet2.Cells[countRepair + countRemoved + 5, 4] = i.Employee;
                            worksheet2.Cells[countRepair + countRemoved + 5, 5] = i.Reason;
                            countRemoved++;
                        }
                    }
                }

                string fileName = String.Empty;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    fileName = saveFileDialog1.FileName;
                } else {
                    return;
                }

                //сохраняем Workbook
                wb.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                wb.Close();
                Excel.Quit();
                saveFileDialog1.Dispose();
            }
            if (res == DialogResult.No) {
                
            }
        }
    }
}