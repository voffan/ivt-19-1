using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comp_park_app.Functions;

namespace Comp_park_app
{
    public partial class Form_addRAM : Form
    {
        public Form_addRAM()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) //Закрытие формы
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) // Добавление в список оперативной памяти
        {
            if (textBox_name.Text.Length != 0 && textBox_Manufacturer.Text.Length != 0 && textBox_capacity.Text.Length != 0) {
                RAMFunctions RAM = new RAMFunctions();
                RAM.Add(textBox_name.Text, textBox_Manufacturer.Text, Convert.ToInt32(textBox_capacity.Text));
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
