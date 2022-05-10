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
using Comp_park_app_form;

namespace Comp_park_app {
    public partial class Form_addComputer : Form {
        bool Type_Add;
        int id;
        Form1 frm1;
        string reason = "";

        public Form_addComputer(bool Add, int index, Form1 fr1) {
            InitializeComponent();
            button_addComputer.Visible = Add;
            button_Edit.Visible = !Add;
            Type_Add = Add;
            id = index;
            frm1 = fr1;
        }


        private void comboBox_HDD_SelectedIndexChanged(object sender, EventArgs e) { //Add item from combobox to listbox
        
            listBox1.Items.Add(comboBox_HDD.SelectedItem);
            comboBox_HDD.Items.Remove(comboBox_HDD.SelectedItem);
        }

        private void comboBox_RAM_SelectedIndexChanged(object sender, EventArgs e) {
            listBox2.Items.Add(comboBox_RAM.SelectedItem);
            comboBox_RAM.Items.Remove(comboBox_RAM.SelectedItem);
        }

        private void comboBox_Processor_SelectedIndexChanged(object sender, EventArgs e) {
            listBox_proc.Items.Add(comboBox_Processor.SelectedItem);
            comboBox_Processor.Items.Remove(comboBox_Processor.SelectedItem);
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e) { //Add item from listbox to combobox
                 
            comboBox_HDD.Items.Add(listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e) {
            comboBox_RAM.Items.Add(listBox2.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);
        }
        private void listBox3_MouseDoubleClick(object sender, MouseEventArgs e) {
            comboBox_Processor.Items.Add(listBox_proc.SelectedItem);
            listBox_proc.Items.Remove(listBox_proc.SelectedItem);
        }

        private void Form_addComputer_Load(object sender, EventArgs e) {
            dateTimePicker1.Value = DateTime.Now;

            foreach (var item in Enum.GetValues(typeof(Status))) {
                comboBox_Status.Items.Add(item);
            }

            comboBox_Status.DropDownStyle = ComboBoxStyle.DropDownList;

            using (Context c = new Context()) {

                List<HDD> hdds = new List<HDD>();
                List<RAM> rams = new List<RAM>();
                List<Processor> procs = new List<Processor>();
                foreach (var i in c.HDDs) {
                    if (i.ComputerId == null) {
                        hdds.Add(i);
                    }
                }
                foreach (var i in c.RAMs) {
                    if (i.ComputerId == null) {
                        rams.Add(i);
                    }
                }
                foreach (var i in c.Processors) {
                    if (i.ComputerId == null) {
                        procs.Add(i);
                    }
                }
                comboBox1.DataSource = hdds;
                //comboBox1.DataSource = c.HDDs.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";

                comboBox2.DataSource = rams;
                //comboBox2.DataSource = c.RAMs.ToList();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";

                comboBox3.DataSource = procs;
                //comboBox3.DataSource = c.Processors.ToList();
                comboBox3.DisplayMember = "Name";
                comboBox3.ValueMember = "Id";

                comboBox_Department.DataSource = c.Departments.ToList();
                comboBox_Department.DisplayMember = "Name";
                comboBox_Department.ValueMember = "Id";
                comboBox_Department.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBox_Employee.DataSource = c.Employees.ToList();
                comboBox_Employee.DisplayMember = "Name";
                comboBox_Employee.ValueMember = "Id";
                comboBox_Employee.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBox_HDD.DisplayMember = "Name";
                comboBox_HDD.ValueMember = "Id";
                comboBox_HDD.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBox_RAM.DisplayMember = "Name";
                comboBox_RAM.ValueMember = "Id";
                comboBox_RAM.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBox_Processor.DisplayMember = "Name";
                comboBox_Processor.ValueMember = "Id";
                comboBox_Processor.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBox_Motherboard.DataSource = c.Motherboards.ToList();
                comboBox_Motherboard.DisplayMember = "Name";
                comboBox_Motherboard.ValueMember = "Id";
                comboBox_Motherboard.DropDownStyle = ComboBoxStyle.DropDownList;

            }

            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Id";

            listBox2.DisplayMember = "Name";
            listBox2.ValueMember = "Id";

            listBox_proc.DisplayMember = "Name";
            listBox_proc.ValueMember = "Id";

            for (int i = 0; i < comboBox1.Items.Count; i++) {
                comboBox_HDD.Items.Add(((HDD)comboBox1.Items[i]));
            }
            for (int i = 0; i < comboBox2.Items.Count; i++) {
                comboBox_RAM.Items.Add(((RAM)comboBox2.Items[i]));
            }
            for (int i = 0; i < comboBox3.Items.Count; i++) {
                comboBox_Processor.Items.Add(((Processor)comboBox3.Items[i]));
            }
            
            if (!Type_Add) {

                Computer comp;
                HDD hdd;
                RAM ram;
                Processor processor;

                using(Context c = new Context()) {

                    comp = c.Computers.Find(id);

                    textBox_ItemNo.Text = comp.ItemNo;
                    comboBox_Status.SelectedItem = comp.Status;
                    dateTimePicker1.Value = comp.Date;
                    textBox_Reason.Text = comp.Reason;

                    foreach (var hd in c.HDDs.ToList()) {

                        if (hd.ComputerId == comp.Id) {

                            listBox1.Items.Add(hd);

                            for (int j = 0; j < comboBox_HDD.Items.Count; j++) {

                                if (((HDD)comboBox_HDD.Items[j]).Id == hd.Id) {

                                    comboBox_HDD.Items.RemoveAt(j);
                                }
                            }
                        }
                    }

                    foreach (var rame in c.RAMs.ToList()) {
                        if (rame.ComputerId == comp.Id) {
                            listBox2.Items.Add(rame);
                            for (int j = 0; j < comboBox_RAM.Items.Count; j++)
                            {
                                if (((RAM)comboBox_RAM.Items[j]).Id == rame.Id)
                                {
                                    comboBox_RAM.Items.RemoveAt(j);
                                }
                            }
                        }
                    }

                    foreach (var proc in c.Processors.ToList())
                    {
                        if (proc.ComputerId == comp.Id)
                        {
                            listBox_proc.Items.Add(proc);
                            for (int j = 0; j < comboBox_Processor.Items.Count; j++)
                            {
                                if (((Processor)comboBox_Processor.Items[j]).Id == proc.Id)
                                {
                                    comboBox_Processor.Items.RemoveAt(j);
                                }
                            }
                        }
                    }

                    /*
                    for (int i = 1; i <= c.HDDs.Count(); i++)
                    {
                        HDD hd = c.HDDs.First(r => r.Id == i);
                        if (hd.ComputerId == comp.Id)
                        {
                            listBox1.Items.Add(hd);
                            for (int j = 0; j < comboBox_HDD.Items.Count; j++) {
                                if (((HDD)comboBox_HDD.Items[j]).Id == hd.Id)
                                {
                                    comboBox_HDD.Items.RemoveAt(j);
                                }
                            }
                        }
                    }
                    
                     for (int i = 1; i <= c.RAMs.Count(); i++)
                    {
                        RAM rame = c.RAMs.First(r => r.Id == i);
                        if (rame.ComputerId == comp.Id)
                        {
                            listBox2.Items.Add(rame);
                            for (int j = 0; j < comboBox_RAM.Items.Count; j++)
                            {
                                if (((RAM)comboBox_RAM.Items[j]).Id == rame.Id)
                                {
                                    comboBox_RAM.Items.RemoveAt(j);
                                }
                            }
                        }
                    }

                    for (int i = 1; i <= c.Processors.Count(); i++)
                    {
                        Processor proc = c.Processors.First(r => r.Id == i);
                        if (proc.ComputerId == comp.Id)
                        {
                            listBox3.Items.Add(proc);
                            for (int j = 0; j < comboBox_Processor.Items.Count; j++)
                            {
                                if (((Processor)comboBox_Processor.Items[j]).Id == proc.Id)
                                {
                                    comboBox_Processor.Items.RemoveAt(j);
                                }
                            }
                        }
                    }
                     */

                    comboBox_Department.SelectedItem = c.Departments.Find(comp.DepartmentId);

                    comboBox_Employee.SelectedItem = c.Employees.Find(comp.EmployeeId);

                    comboBox_Motherboard.SelectedItem = c.Motherboards.Find(comp.MotherboardId);
                }
                //For edit mode
            }
        }

        private void button_addComputer_Click(object sender, EventArgs e) {
            if (comboBox_Department.SelectedIndex >= 0 && textBox_ItemNo.Text.Length != 0 &&
                comboBox_Status.SelectedIndex >=0 && comboBox_Employee.SelectedIndex >= 0 &&
                listBox1.Items.Count > 0 && listBox2.Items.Count > 0 && listBox_proc.Items.Count > 0 &&
                comboBox_Motherboard.SelectedIndex >= 0) {

                var departmentid = Convert.ToInt32(comboBox_Department.SelectedValue);
                var itemno = textBox_ItemNo.Text;
                Status status = (Status)comboBox_Status.SelectedItem;
                var employeeid = Convert.ToInt32(comboBox_Employee.SelectedValue);
                DateTime date = dateTimePicker1.Value;
                reason = textBox_Reason.Text;
                var hdds = listBox1.Items.Cast<HDD>().ToList();
                var rams = listBox2.Items.Cast<RAM>().ToList();
                var processors = listBox_proc.Items.Cast<Processor>().ToList();
                var motherboardid = Convert.ToInt32(comboBox_Motherboard.SelectedValue);
                ComputerFunctions Computer = new ComputerFunctions();
                Computer.Add(departmentid, itemno, status, motherboardid, employeeid, hdds, rams, processors, date, reason);
                frm1.Update_datagridview(0);
                this.Close();
            } else {
                MessageBox.Show("Error");
            }
        }

        private void button_Edit_Click(object sender, EventArgs e) {
            if (comboBox_Department.SelectedIndex >= 0 && textBox_ItemNo.Text.Length != 0 &&
                comboBox_Status.SelectedIndex >= 0 && comboBox_Employee.SelectedIndex >= 0 &&
                listBox1.Items.Count > 0 && listBox2.Items.Count > 0 && listBox_proc.Items.Count > 0 &&
                comboBox_Motherboard.SelectedIndex >= 0) {
                var departmentid = Convert.ToInt32(comboBox_Department.SelectedValue);
                var itemno = textBox_ItemNo.Text;
                Status status = (Status)comboBox_Status.SelectedItem;
                var employeeid = Convert.ToInt32(comboBox_Employee.SelectedValue);
                DateTime date = dateTimePicker1.Value;
                reason = textBox_Reason.Text;
                var hdds = listBox1.Items.Cast<HDD>().ToList();
                var rams = listBox2.Items.Cast<RAM>().ToList();
                List<Processor> processors = listBox_proc.Items.Cast<Processor>().ToList(); 
                var motherboardid = Convert.ToInt32(comboBox_Motherboard.SelectedValue);

                ComputerFunctions Computer = new ComputerFunctions();
                Computer.Edit(id, departmentid, itemno, status, motherboardid, employeeid, hdds, rams, processors, date, reason);
                frm1.Update_datagridview(0);
                this.Close();
            } else {
                MessageBox.Show("Error");
            }
        }
    }
}
