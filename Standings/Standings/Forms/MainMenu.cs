using Standings.Database;
using Standings.Forms;
using Standings.Forms.Add;
using Standings.Forms.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            dataGridView1.DataSource = context.Sportsmans.ToList();
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
                AddSportsman AC = new AddSportsman();
                AC.ShowDialog();
                InitTablSportsmans();
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (k == 1)
            {
                int Id  = dataGridView1.CurrentRow.Index;
                UpdateEmployee UE = new UpdateEmployee();
               
                UE.FullName1.Text = dataGridView1.Rows[Id].Cells[3].Value.ToString();
                UE.comboBox1.Text = dataGridView1.Rows[Id].Cells[4].Value.ToString(); 
                UE.ShowDialog();
                InitTablEmployees();
            }
            if (k == 2)
            {
                int Id = dataGridView1.CurrentRow.Index;
                InitTablCompetitions();
            }
            if (k == 3)
            {
                int Id = dataGridView1.CurrentRow.Index;
                InitTablSportsmans();
            }

        }
    }
}
