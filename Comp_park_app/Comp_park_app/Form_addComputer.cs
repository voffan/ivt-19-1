using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp_park_app
{
    public partial class Form_addComputer : Form
    {
        public Form_addComputer()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_RAM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form_addComputer_Load(object sender, EventArgs e)
        {
            using (Context c = new Context()) {
                comboBox_HDD.DataSource = c.HDDs.ToList();
                comboBox_HDD.DisplayMember = "Name";
                comboBox_HDD.ValueMember = "Id";

                comboBox_RAM.DataSource = c.RAMs.ToList();
                comboBox_RAM.DisplayMember = "Name";
                comboBox_RAM.ValueMember = "Id";

                comboBox_Processor.DataSource = c.Processors.ToList();
                comboBox_Processor.DisplayMember = "Name";
                comboBox_Processor.ValueMember = "Id";

                comboBox_Motherboard.DataSource = c.Motherboards.ToList();
                comboBox_Motherboard.DisplayMember = "Name";
                comboBox_Motherboard.ValueMember = "Id";
            }
                
        }

        
    }
}
