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
using Standings.Database;

namespace Standings.Forms.Add
{
    public partial class AddSportsman : Form
    {
        public AddSportsman()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void password2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = Name1.Text;



            bool b = Invalid.Checked;



            double Ves = Convert.ToDouble(this.Ves.Text);


            Nationality Nation = (Nationality)comboBox1.SelectedItem;


            DateTime Date = dateTimePicker1.Value;

            Sex Sex = (Sex)Enum.Parse(typeof(Sex), Pol.Text);
            StatusSport StatusSport = (StatusSport)Enum.Parse(typeof(StatusSport), Active.Text);
            if (Name1.Text == "" || this.Ves.Text == "")
            {
                MessageBox.Show("Заполните ВСЕ поля!");
            }
            else
            {
                SportsmanFunctions.Add(Name, b, Ves, Date, Sex, StatusSport, Nation);
                this.Close();

            }
        }

        private void AddSportsman_Load(object sender, EventArgs e)
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

        private void Active_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Invalid_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Pol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Ves_TextChanged(object sender, EventArgs e)
        {

        }

        private void Name1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
