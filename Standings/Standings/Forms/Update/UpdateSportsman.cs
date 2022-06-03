using Standings.Database;
using Standings.Functions;
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

namespace Standings.Forms.Update
{
    public partial class UpdateSportsman : Form
    {
        int id;
        public UpdateSportsman(int obj_id)
        {
            InitializeComponent();
            id = obj_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = Name1.Text;
            bool b = Invalid.Checked;
            double Ves = Convert.ToDouble(this.Ves.Text);
            Nationality Nation = (Nationality)comboBox1.SelectedItem;
            Sex Sex = (Sex)Enum.Parse(typeof(Sex), Pol.Text);
            StatusSport StatusSport = (StatusSport)Enum.Parse(typeof(StatusSport), Active.Text);
            if (Name1.Text == "" || this.Ves.Text == "")
            {
                MessageBox.Show("Заполните ВСЕ поля!");
            }
            else
            {
                SportsmanFunctions.Edit(Name, b, Ves, Sex, StatusSport, Nation, id);
                this.Close();

            }

        }

        private void UpdateSportsman_Load(object sender, EventArgs e)
        {
            Pol.DataSource = Enum.GetValues(typeof(Sex));
            Active.DataSource = Enum.GetValues(typeof(StatusSport));
            using (Context c = new Context())
            {
                comboBox1.DataSource = c.Nationalitys.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }
        }
    }
}
