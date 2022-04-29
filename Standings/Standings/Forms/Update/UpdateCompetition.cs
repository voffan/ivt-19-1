using Standings.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Standings.Functions;
using MySql.Data.MySqlClient;
using Standings.Database;

namespace Standings.Forms.Update
{
    public partial class UpdateCompetition : Form
    {
        int id;
        public UpdateCompetition(int obj_id)
        {
            InitializeComponent();
            id = obj_id;
        }

        private void UpdateCompetition_Load(object sender, EventArgs e)
        {
            Level1.DataSource = Enum.GetValues(typeof(Level));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = Name1.Text,
            Location = Location1.Text;
            DateTime Date = Date1.Value;

            Level Level = (Level)Enum.Parse(typeof(Level), Level1.Text);

            if (Name1.Text == "" || Level1.Text == "" || Location1.Text == "")
            {
                MessageBox.Show("Заполните ВСЕ поля!");
            }
            else
            {
                CompetitionFunctions.Edit(Name, Location, Date, Level, id);
                this.Close();

            }
        }
    }
}
