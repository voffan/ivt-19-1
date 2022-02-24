using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Autoreport.Database;
using Autoreport.Models;
using Microsoft.EntityFrameworkCore;

namespace Autoreport.UI
{
    public partial class MainWindow : Form
    {
        Login Loginer;
        Button currentButton;
        Form currentAddForm;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Login();
            employeesBtn.PerformClick();
        }

        private void Login()
        {
            Loginer = new Login();
            Loginer.ShowDialog();
        }

        private void employeersBtn_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            currentAddForm = new AddEmployeeForm();
            dataGridView.DataSource = Connection.employeerService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void clientsBtn_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.clientService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void disksBtn_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.diskService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void filmsBtn_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.filmService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void ordersBtn_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.orderService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void depositsBtn_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.depositService.GetAll();
            dataGridView.Columns["Id"].Visible = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            currentAddForm.Show();
        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            currentButton.PerformClick();
        }
    }
}
