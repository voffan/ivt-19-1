using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comp_park_app.Functions;

namespace Comp_park_app
{
    public partial class Form_addPeripheral : Form
    {
        bool Type_Add;
        int id;
        public Form_addPeripheral(bool Add, int index)
        {
            InitializeComponent();
            button1.Visible = Add;
            button_Edit.Visible = !Add;
            Type_Add = Add;
            id = index;
        }
        private void button2_Click(object sender, EventArgs e) //Закрытие формы
        {
            this.Close();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            
                foreach (var item in Enum.GetValues(typeof(Status)))
                {
                    comboBox_Status.Items.Add(item);
                }
                using (Context c = new Context())
                {
                    comboBox_Department.DataSource = c.Departments.ToList();
                    comboBox_Department.DisplayMember = "Name";
                    comboBox_Department.ValueMember = "Id";

                    comboBox_Employee.DataSource = c.Employees.ToList();
                    comboBox_Employee.DisplayMember = "Name";
                    comboBox_Employee.ValueMember = "Id";
                }
            
            if (!Type_Add)
            {
                Peripheral peripheral;
                using (Context c = new Context())
                {
                    peripheral = c.Peripherals.Find(id);
                    textBox_name.Text = peripheral.Name;
                    textBox_itemno.Text = peripheral.ItemNo;
                    comboBox_Status.SelectedItem = peripheral.Status;
                    comboBox_Department.SelectedItem = peripheral.Department;
                    comboBox_Employee.SelectedItem = peripheral.Employee;
                }
                //For edit mode
            }
        }

        // При нажатии кнопки создается новый экземпляр класса и вызывается метод Add, которому передается три аргумента
        // (Наименование, производитель и обьем оперативной памяти), который добавляет в список новый элемент,
        // если все поля заполнены, в противной случае вызывает окно с ошибкой
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text.Length != 0 && textBox_itemno.Text.Length != 0 &&
                comboBox_Department.SelectedIndex >= 0 && comboBox_Employee.SelectedIndex >= 0)
            {
                PeripheralFunctions Peripheral = new PeripheralFunctions();
                var name = textBox_name.Text;
                var itemno = textBox_itemno.Text;
                var status = (Status)comboBox_Status.SelectedItem;
                var departmentid = Convert.ToInt32(comboBox_Department.SelectedValue);
                var employeeid = Convert.ToInt32(comboBox_Employee.SelectedValue);
                Peripheral.Add(name, itemno, status, departmentid, employeeid);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text.Length != 0 && textBox_itemno.Text.Length != 0 &&
                comboBox_Department.SelectedIndex >= 0 && comboBox_Employee.SelectedIndex >= 0)
            {
                PeripheralFunctions Peripheral = new PeripheralFunctions();
                var name = textBox_name.Text;
                var itemno = textBox_itemno.Text;
                var status = (Status)comboBox_Status.SelectedItem;
                var departmentid = Convert.ToInt32(comboBox_Department.SelectedValue);
                var employeeid = Convert.ToInt32(comboBox_Employee.SelectedValue);
                Peripheral.Edit(id, name, itemno, status, departmentid, employeeid);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
