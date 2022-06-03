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
    public partial class UpdateResult : Form
    {
        int id;
        public UpdateResult(int obj_id)
        {
            InitializeComponent();
            id = obj_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sportsman sportsman = (Sportsman)comboBox1.SelectedItem;
            SportKind kind = (SportKind)comboBox3.SelectedItem;
            Category category = (Category)comboBox2.SelectedItem;
            Competition competition = (Competition)comboBox4.SelectedItem;
            string record = Record1.Text;

            if (Record1.Text == "")
            {
                MessageBox.Show("Заполните ВСЕ поля!");
            }
            else
            {
                ResultFunctions.Edit(sportsman, kind, category, record, competition, id);
                this.Close();

            }
        }

        private void UpdateResult_Load(object sender, EventArgs e)
        {
            
            using (Context c = new Context())
            {
                Result r = c.Results.Find(id);
                comboBox1.DataSource = c.Sportsmans.ToList();
                comboBox1.DisplayMember = "FullName";
                comboBox1.ValueMember = "Id";

                comboBox3.DataSource = c.SportKinds.ToList();
                comboBox3.DisplayMember = "Name";
                comboBox3.ValueMember = "Id";

                comboBox4.DataSource = c.Competitions.ToList();
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "Id";

                //
                //comboBox4.SelectedIndex = comboBox4.for;

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
