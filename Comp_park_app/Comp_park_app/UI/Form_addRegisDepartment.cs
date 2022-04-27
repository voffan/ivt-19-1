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
            DepartmentFunctions Department = new DepartmentFunctions();
            Department.Add(textBox_name.Text, Convert.ToInt32(textBox_Manufacturer.Text));
            regEmp.EmpUpdate();
            this.Close();
        }
    }
}
