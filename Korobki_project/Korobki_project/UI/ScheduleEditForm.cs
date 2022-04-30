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

namespace Korobki_project.UI
{
    public partial class ScheduleEditForm : Form
    {
        int id;
        public ScheduleEditForm(int index)
        {
            InitializeComponent();
            id = index;
        }

        private void ScheduleEditForm_Load(object sender, EventArgs e)
        {
            Schedule schedule;
            using (Context c = new Context())
            {
                schedule = c.Schedules.Find(id);
                textBox1.Text = schedule.PlanCount.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(schedule.Date);

                comboBox1.DataSource = c.Shifts.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedItem = c.Shifts.Find(schedule.ShiftId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0 && comboBox1.SelectedIndex >= 0)
            {

                ScheduleFunctions schedule = new ScheduleFunctions();
                var plancount =Convert.ToInt32(textBox1.Text);
                var shiftid = Convert.ToInt32(comboBox1.SelectedValue);
                var date = dateTimePicker1.Value;
                schedule.Edit(id, shiftid, date,plancount);
                this.Close();
            }
            else MessageBox.Show("Ошибка заполните все поля");
        }
    }
}
