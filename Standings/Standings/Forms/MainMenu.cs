﻿using Standings.Database;
using Standings.Forms;
using Standings.Forms.Add;
using Standings.Forms.Update;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Standings
{
    public partial class MainMenu : Form
    {
        Action<int> currentDeleteAction;
        List<Button> currentlyPermittedActions = new List<Button>();
        DataGridViewCellEventHandler tableItemDoubleClickEvent;
        public MainMenu()
        {
            InitializeComponent();
        }
        int k = 0;
        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!currentlyPermittedActions.Contains(button3))
                return;

            if (dataGridView1.SelectedRows.Count == 0)
                button3.Enabled = false;
            else
                button3.Enabled = true;
        }
        private void InitTablEmployees()
        {
            Context context = Connection.Connect();
            dataGridView1.DataSource = context.Employees.ToList();
        }
        private void InitTablCompetitions()
        {
            Context context = Connection.Connect();
            dataGridView1.DataSource = context.Competitions.ToList();
        }
        private void InitTablSportsmans()
        {
            Context context = Connection.Connect();
            dataGridView1.DataSource = context.Sportsmans.Include("Nationality").ToList();
        }
        private void InitTablResult()
        {
            Context context = Connection.Connect();
            dataGridView1.DataSource = context.Results.Include("Sportsman").Include("SportKind").Include("Category").ToList();
            
        }
        private void списокСотрудниковToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            k = 1;
            InitTablEmployees();       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (k == 1)
            {
                AddEmployee AE = new AddEmployee();
                AE.ShowDialog();
                InitTablEmployees();
            }
            if (k == 2)
            {
                AddCompetition AC = new AddCompetition();
                AC.ShowDialog();
                InitTablCompetitions();
            }
            if (k == 3)
            {
                AddSportsman AS = new AddSportsman();
                AS.ShowDialog();
                InitTablSportsmans();
            }
            if (k == 4)
            {
                AddResult AR = new AddResult();
                AR.ShowDialog();
                InitTablResult();
            }

        }

        private void списокСоревнованийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k = 2;
            InitTablCompetitions();
        }

        private void списокСпорстменовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k = 3;
            InitTablSportsmans();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (k == 1)
            {
                currentDeleteAction = Connection.employeeFunctions.Delete;

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    currentDeleteAction((int)row.Cells["Id"].Value);
                }
                InitTablEmployees();
            }
            if (k == 2)
            {
                currentDeleteAction = Connection.competitionFunctions.Delete;

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    currentDeleteAction((int)row.Cells["Id"].Value);
                }
                InitTablCompetitions();
            }
            if (k == 3)
            {
                currentDeleteAction = Connection.sportsmanFunctions.Delete;

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    currentDeleteAction((int)row.Cells["Id"].Value);
                }
                InitTablSportsmans();
            }
            if (k == 4)
            {
                currentDeleteAction = Connection.resultFunctions.Delete;

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    currentDeleteAction((int)row.Cells["Id"].Value);
                }
                InitTablResult();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (k == 1)
            {
                int Id  = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                UpdateEmployee UE = new UpdateEmployee(Id);
               
                UE.FullName1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                UE.comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                UE.password1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                
                UE.ShowDialog();
                InitTablEmployees();
            }
            if (k == 2)
            {
                int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                UpdateCompetition UC = new UpdateCompetition(Id);

                UC.Name1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                UC.Level1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                UC.Date1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                UC.Location1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                UC.ShowDialog();
                InitTablCompetitions();
            }
            if (k == 3)
            {
                int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                UpdateSportsman US = new UpdateSportsman(Id);

                US.Name1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                US.Invalid.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value);

                US.comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                US.Ves.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                US.Pol.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                US.Active.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                US.ShowDialog();
                InitTablSportsmans();
            }
            if (k == 4)
            {
                int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                UpdateResult UR = new UpdateResult(Id);


                UR.comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                UR.comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                UR.Record1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                UR.comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                
                UR.ShowDialog();
                InitTablResult();
            }

        }

        private void списокРезультатовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k = 4;
            InitTablResult();
        }
    }
}
