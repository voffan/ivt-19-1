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
    public partial class Form_addComputer : Form
    {
        public Form_addComputer()
        {
            InitializeComponent();
        }


        private void comboBox_HDD_SelectedIndexChanged(object sender, EventArgs e)//Add item from combobox to listbox
        {
            
            listBox1.Items.Add(comboBox_HDD.SelectedItem);
            comboBox_HDD.Items.Remove(comboBox_HDD.SelectedItem);
        }

        private void comboBox_RAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Add(comboBox_RAM.SelectedItem);
            comboBox_RAM.Items.Remove(comboBox_RAM.SelectedItem);
        }

        private void comboBox_Processor_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Add(comboBox_Processor.SelectedItem);
            comboBox_Processor.Items.Remove(comboBox_Processor.SelectedItem);
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e) //Add item from listbox to combobox
        {
            
            comboBox_HDD.Items.Add(listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            comboBox_RAM.Items.Add(listBox2.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);
        }
        private void listBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            comboBox_Processor.Items.Add(listBox3.SelectedItem);
            listBox3.Items.Remove(listBox3.SelectedItem);
        }

        private void Form_addComputer_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(Status)))
            {
                comboBox_Status.Items.Add(item);
            }

            using (Context c = new Context()) {
                comboBox1.DataSource = c.HDDs.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";

                comboBox2.DataSource = c.RAMs.ToList();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";

                comboBox3.DataSource = c.Processors.ToList();
                comboBox3.DisplayMember = "Name";
                comboBox3.ValueMember = "Id";

                comboBox_Department.DataSource = c.Departments.ToList();
                comboBox_Department.DisplayMember = "Name";
                comboBox_Department.ValueMember = "Id";

                comboBox_Employee.DataSource = c.Employees.ToList();
                comboBox_Employee.DisplayMember = "Name";
                comboBox_Employee.ValueMember = "Id";

                //comboBox_HDD.DataSource = c.HDDs.ToList();
                comboBox_HDD.DisplayMember = "Name";
                comboBox_HDD.ValueMember = "Id";

                //comboBox_RAM.DataSource = c.RAMs.ToList();
                comboBox_RAM.DisplayMember = "Name";
                comboBox_RAM.ValueMember = "Id";

                //comboBox_Processor.DataSource = c.Processors.ToList();
                comboBox_Processor.DisplayMember = "Name";
                comboBox_Processor.ValueMember = "Id";

                comboBox_Motherboard.DataSource = c.Motherboards.ToList();
                comboBox_Motherboard.DisplayMember = "Name";
                comboBox_Motherboard.ValueMember = "Id";
                
            }

            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Id";

            listBox2.DisplayMember = "Name";
            listBox2.ValueMember = "Id";

            listBox3.DisplayMember = "Name";
            listBox3.ValueMember = "Id";

            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                comboBox_HDD.Items.Add(((HDD)comboBox1.Items[i]));
            }
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                comboBox_RAM.Items.Add(((RAM)comboBox2.Items[i]));
            }
            for (int i = 0; i < comboBox3.Items.Count; i++)
            {
                comboBox_Processor.Items.Add(((Processor)comboBox3.Items[i]));
            }

        }

        private void button_addComputer_Click(object sender, EventArgs e)
        {
            if (comboBox_Department.SelectedIndex >= 0 && textBox_ItemNo.Text.Length != 0 &&
                comboBox_Status.SelectedIndex >=0 && comboBox_Employee.SelectedIndex >= 0 &&
                listBox1.Items.Count > 0 && listBox2.Items.Count > 0 && listBox3.Items.Count > 0 &&
                comboBox_Motherboard.SelectedIndex >= 0)
            {
                ((HDD)listBox1.Items[0]).Id += 6;
                ((RAM)listBox2.Items[0]).Id += 6;
                ((Processor)listBox3.Items[0]).Id += 6;

                var departmentid = Convert.ToInt32(comboBox_Department.SelectedValue);
                var itemno = textBox_ItemNo.Text;
                Status status = (Status)comboBox_Status.SelectedItem;
                var employeeid = Convert.ToInt32(comboBox_Employee.SelectedValue);

                
                var hdds = listBox1.Items.Cast<HDD>().ToList();
                var rams = listBox2.Items.Cast<RAM>().ToList();
                var processors = listBox3.Items.Cast<Processor>().ToList();
                var motherboardid = Convert.ToInt32(comboBox_Motherboard.SelectedValue);
                ComputerFunctions Computer = new ComputerFunctions();
                Computer.Add(departmentid, itemno, status, motherboardid, employeeid, hdds, rams, processors);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
