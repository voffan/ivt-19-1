using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Korobki_project;

namespace Korobki_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Context c = new Context();
            dataGridView1.DataSource = c.Employees.ToList();
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    Context c0 = new Context();
                    dataGridView1.DataSource = c0.Employees.ToList();
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    break;
                case 1:
                    Context c1 = new Context();
                    dataGridView1.DataSource = c1.Plans.ToList();

                    break;
                case 2:
                    Context c2 = new Context();
                    dataGridView1.DataSource = c2.Productions.ToList();

                    break;
                case 3:
                    Context c3 = new Context();
                    dataGridView1.DataSource = c3.Products.ToList();

                    break;
                case 4:
                    Context c4 = new Context();
                    dataGridView1.DataSource = c4.Shifts.ToList();

                    break;
                case 5:
                    Context c5 = new Context();
                    dataGridView1.DataSource = c5.Schedules.ToList();

                    break;
                case 6:
                    Context c6 = new Context();
                    dataGridView1.DataSource = c6.Typees.ToList();

                    break;
      
            }
            label1.Text = "Текущий столбец: " + listBox1.SelectedItem.ToString();
        }
    }
}
