using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comp_park_app;
using Comp_park_app.UI;

namespace Comp_park_app_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Context c = new Context();
            dataGridView1.DataSource = c.Computers.ToList();
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            ExitCheck exit = new ExitCheck();
            if (exit.ShowDialog() == DialogResult.OK)
            {
                //Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0://Computer
                    Context c0 = new Context();
                    dataGridView1.DataSource = c0.Computers.ToList();
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    break;
                case 1:
                    Context c1 = new Context();
                    dataGridView1.DataSource = c1.Departments.ToList();
                    
                    break;
                case 2:
                    Context c2 = new Context();
                    dataGridView1.DataSource = c2.Employees.ToList();
                    
                    break;
                case 3:
                    Context c3 = new Context();
                    dataGridView1.DataSource = c3.HDDs.ToList();

                    break;
                case 4:
                    Context c4 = new Context();
                    dataGridView1.DataSource = c4.Motherboards.ToList();

                    break;
                case 5:
                    Context c5 = new Context();
                    dataGridView1.DataSource = c5.Peripherals.ToList();

                    break;
                case 6:
                    Context c6 = new Context();
                    dataGridView1.DataSource = c6.Processors.ToList();

                    break;
                case 7:
                    Context c7 = new Context();
                    dataGridView1.DataSource = c7.RAMs.ToList();

                    break;
            }
            label2.Text = "Текущий столбец: " + listBox1.SelectedItem.ToString();
        }

        
    }
}
