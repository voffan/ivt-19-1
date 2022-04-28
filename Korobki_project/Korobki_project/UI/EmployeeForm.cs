﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Korobki_project;
using Microsoft.EntityFrameworkCore;
using Korobki_project.UI;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace Korobki_project
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
            Context c = new Context();
            dataGridView1.DataSource = c.Employees.Include("Position").Include("Shift").OrderBy(e=>e.Name).ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            //this.dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Ascending);

        }

        private void EmployeeForm_FormClosed_1(object sender, FormClosedEventArgs e)
		{
        /*   
            MenuForm main = new MenuForm();
            main.Show();
        */
        }
	}
}
