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


namespace Standings.Forms.Add
{
    public partial class AddResult : Form
    {
        public AddResult()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sportsman sportsman = (Sportsman)comboBox1.SelectedItem;
            Category category = (Category)comboBox2.SelectedItem;
            SportKind sportkind = (SportKind)comboBox3.SelectedItem;
            Competition competition = (Competition)comboBox4.SelectedItem;
            string Record = Record1.Text;
            if (Record1.Text == "")
            {
                MessageBox.Show("Заполните ВСЕ поля!");
            }
            else
            {
                ResultFunctions.Add(sportsman, category, competition, sportkind, Record);
                this.Close();

            }
        }

        private void AddResult_Load(object sender, EventArgs e)
        {
            using (Context c = new Context())
            {
                comboBox1.DataSource = c.Sportsmans.ToList();
                comboBox1.DisplayMember = "FullName";
                comboBox1.ValueMember = "Id";

                comboBox3.DataSource = c.SportKinds.ToList();
                comboBox3.DisplayMember = "Name";
                comboBox3.ValueMember = "Id";

                comboBox4.DataSource = c.Competitions.ToList();
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "Id";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.ValueMember.Length < 1) return;
            using (Context c = new Context())
            {
                comboBox2.DataSource = c.Categorys.
                Where(q => q.SportKindId == Convert.ToInt32(comboBox3.SelectedValue)).
                ToList();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
