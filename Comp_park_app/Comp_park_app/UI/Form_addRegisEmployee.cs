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

namespace Comp_park_app.UI
{
    public partial class Form_addRegisEmployee : Form
    {
        public Form_addRegisEmployee()
        {
            InitializeComponent();
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (textBox_Name.Text.Length != 0 && textBox_Department.Text.Length >= 0 && textBox_Position.Text.Length >= 0 && textBox_Password.Text.Length >= 0)
            {
                EmployeeFunctions employee = new EmployeeFunctions();
                var name = textBox_Name.Text;
                var password = textBox_Password.Text;
                var departmentid = Convert.ToInt32(textBox_Department.Text);
                var positionid = Convert.ToInt32(textBox_Position.Text);
                employee.Add(name, departmentid, positionid, password);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
