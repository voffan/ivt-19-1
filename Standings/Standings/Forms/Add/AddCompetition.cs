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
using Standings.Models;

namespace Standings.Forms.Add
{
    public partial class AddCompetition : Form
    {
        public AddCompetition()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
                     CompetitionFunctions.Add(Name, Location, Date, Level);
                     this.Close();

                }
        }

        private void Level1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddCompetition_Load(object sender, EventArgs e)
        {
            Level1.DataSource = Enum.GetValues(typeof(Level));
        }
    }
}
