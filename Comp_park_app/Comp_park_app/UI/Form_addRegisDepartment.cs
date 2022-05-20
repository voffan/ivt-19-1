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

    public partial class Form_addRegisDepartment : Form {
        Form_addRegisEmployee regEmp = new Form_addRegisEmployee();
        public Form_addRegisDepartment(Form_addRegisEmployee frm) {
            InitializeComponent();
            regEmp = frm;
        }

        private void button_Edit_Click(object sender, EventArgs e) {
            if (textBox_name.Text.Length != 0 && numericUpDown_number.Value > 0)
            {
                DepartmentFunctions Department = new DepartmentFunctions();
                Department.Add(textBox_name.Text, (int)numericUpDown_number.Value);
                regEmp.EmpUpdate();
                this.Close();
            } else {
                MessageBox.Show("Не все поля заполнены");
            }
                
        }
    }
}
