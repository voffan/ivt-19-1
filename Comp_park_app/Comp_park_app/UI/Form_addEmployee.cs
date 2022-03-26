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
    public partial class Form_addEmployee : Form
    {
        bool Type_Add;
        int id;
        public Form_addEmployee(bool Add, int index)
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
            
                using (Context c = new Context())
                {
                    comboBox_Department.DataSource = c.Departments.ToList();
                    comboBox_Department.DisplayMember = "Name";
                    comboBox_Department.ValueMember = "Id";

                    comboBox_Position.DataSource = c.Positions.ToList();
                    comboBox_Position.DisplayMember = "Name";
                    comboBox_Position.ValueMember = "Id";
                }
            
            if (!Type_Add)
            {
                Employee employee;
                using(Context c = new Context())
                {
                    employee = c.Employees.Find(id);
                    textBox_name.Text = employee.Name;
                    comboBox_Department.SelectedItem = employee.Department;
                    comboBox_Position.SelectedItem = employee.Position;
                }
                //For edit mode
            }

        }
        // При нажатии кнопки создается новый экземпляр класса и вызывается метод Add, которому передается три аргумента
        // (Наименование, производитель и обьем оперативной памяти), который добавляет в список новый элемент,
        // если все поля заполнены, в противной случае вызывает окно с ошибкой
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text.Length != 0 && comboBox_Department.SelectedIndex >= 0 && comboBox_Position.SelectedIndex >= 0)
            {
                EmployeeFunctions employee = new EmployeeFunctions();
                var name = textBox_name.Text;
                var departmentid = Convert.ToInt32(comboBox_Department.SelectedValue);
                var positionid = Convert.ToInt32(comboBox_Position.SelectedValue);
                employee.Add(name, departmentid, positionid);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text.Length != 0 && comboBox_Department.SelectedIndex >= 0 && comboBox_Position.SelectedIndex >= 0)
            {
                EmployeeFunctions employee = new EmployeeFunctions();
                var name = textBox_name.Text;
                var departmentid = Convert.ToInt32(comboBox_Department.SelectedValue);
                var positionid = Convert.ToInt32(comboBox_Position.SelectedValue);
                employee.Edit(id, name, departmentid, positionid);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
