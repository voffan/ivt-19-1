using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Korobki_project.Classes;
using Korobki_project.Functions;
using Korobki_project;

namespace Korobki_project.UI
{
    public partial class EmployeeEditForm : Form
    {
        int id;
        public EmployeeEditForm(int index)
        {
            InitializeComponent();
            id = index;

        }

        private void EmployeeEditForm_Load(object sender, EventArgs e)
        {
           
            Employee empl;
            using (Context c = new Context())
            {
                empl = c.Employees.Find(id);
                textBox1.Text = empl.Name;
                textBox2.Text = empl.Login;
                textBox3.Text = empl.Password;
                textBox4.Text = empl.PhoneNumber;
                textBox5.Text = empl.Adress;
                
                
                comboBox1.DataSource = c.Positions.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedItem = c.Positions.Find(empl.PositionId);

                comboBox2.DataSource = c.Shifts.ToList();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
                comboBox2.SelectedItem = c.Shifts.Find(empl.ShiftId);
            } 
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox3.TextLength != 0 && textBox4.TextLength != 0 && textBox5.TextLength != 0 && comboBox1.SelectedIndex>=0 && comboBox2.SelectedIndex >= 0 )
            {
                
                EmployeeFunctions employee = new EmployeeFunctions();
                var name = textBox1.Text;
                var login = textBox2.Text;
                var password = textBox3.Text;
                var positionid = Convert.ToInt32(comboBox1.SelectedValue);
                var phonenumber = textBox4.Text;
                var adress = textBox5.Text;
                var shiftid = Convert.ToInt32(comboBox2.SelectedValue);
                employee.Edit(id, name, login, password, positionid, phonenumber, adress, shiftid);
                this.Close();
            }
        }
    }
}
