using Comp_park_app.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp_park_app.UI {
    public partial class Form_addRegisEmployee : Form {

        public Form_addRegisEmployee() {
            InitializeComponent();
        }

        private void button_Edit_Click(object sender, EventArgs e) {
            if (textBox_Name.Text.Length != 0 && comboBox_Department.Text.Length >= 0 && comboBox_Position.Text.Length >= 0 && textBox_Password.Text.Length >= 0) {
                if (EmployeeFunctions.CheckForDuplicates(textBox_Name.Text)) {
                    EmployeeFunctions employee = new EmployeeFunctions();
                    var name = textBox_Name.Text;
                    var password = textBox_Password.Text;
                    var departmentid = Convert.ToInt32(comboBox_Department.SelectedValue);
                    var positionid = Convert.ToInt32(comboBox_Position.SelectedValue);
                    employee.Add(name, departmentid, positionid, password);
                    this.Close();
                } else { 
                    MessageBox.Show("Пользователь с таким ФИО уже существует");
                }
            }
            else {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            Form_addRegisDepartment regDepart = new Form_addRegisDepartment(this);
            regDepart.ShowDialog();
        }

        private void button_addPositon_Click(object sender, EventArgs e) {
            Form_addRegisPosition regPos = new Form_addRegisPosition(this);
            regPos.ShowDialog();
        }

        private void Form_addRegisEmployee_Load(object sender, EventArgs e) {
            using (Context c = new Context()) {
                comboBox_Department.DataSource = c.Departments.ToList();
                comboBox_Department.DisplayMember = "Name";
                comboBox_Department.ValueMember = "Id";
                comboBox_Department.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBox_Position.DataSource = c.Positions.ToList();
                comboBox_Position.DisplayMember = "Name";
                comboBox_Position.ValueMember = "Id";
                comboBox_Position.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        public void EmpUpdate() {
            using (Context c = new Context()) {
                comboBox_Department.DataSource = c.Departments.ToList();
                comboBox_Department.DisplayMember = "Name";
                comboBox_Department.ValueMember = "Id";
                comboBox_Department.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBox_Position.DataSource = c.Positions.ToList();
                comboBox_Position.DisplayMember = "Name";
                comboBox_Position.ValueMember = "Id";
                comboBox_Position.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
