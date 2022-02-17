﻿using System;
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
using Microsoft.EntityFrameworkCore;

namespace Autoreport.UI
{
    public partial class MainWindow : Form
    {
        Login Loginer;
        Button currentButton;

        public MainWindow()
        {
            Connection.Connect();
            InitializeComponent();
            Login();
            employeersBtn.PerformClick();
        }

        private void Login()
        {
            Loginer = new Login();
            Loginer.Show();
        }

        private void employeersBtn_Click(object sender, EventArgs e)
        {
            if (currentButton == (Button)sender)
            {
                return;
            }

            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.Context.Employeers.ToList();
            dataGridView.Columns[0].Visible = false;
        }

        private void clientsBtn_Click(object sender, EventArgs e)
        {
            if (currentButton == (Button)sender)
            {
                return;
            }

            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.Context.Clients.ToList();
            dataGridView.Columns[0].Visible = false;
        }

        private void disksBtn_Click(object sender, EventArgs e)
        {
            if (currentButton == (Button)sender)
            {
                return;
            }

            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.Context.Disks.ToList();
            dataGridView.Columns[0].Visible = false;
        }

        private void filmsBtn_Click(object sender, EventArgs e)
        {
            if (currentButton == (Button)sender)
            {
                return;
            }

            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.Context.Films.ToList();
            dataGridView.Columns[0].Visible = false;
        }

        private void ordersBtn_Click(object sender, EventArgs e)
        {
            if (currentButton == (Button)sender)
            {
                return;
            }

            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.Context.Orders.ToList();
            dataGridView.Columns[0].Visible = false;
        }

        private void depositsBtn_Click(object sender, EventArgs e)
        {
            if (currentButton == (Button)sender)
            {
                return;
            }

            currentButton = (Button)sender;
            dataGridView.DataSource = Connection.Context.Deposits.ToList();
            dataGridView.Columns[0].Visible = false;
        }
    }
}
