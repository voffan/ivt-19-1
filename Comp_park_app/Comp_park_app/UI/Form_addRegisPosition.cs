using Comp_park_app.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp_park_app.UI {
    
    public partial class Form_addRegisPosition : Form {
        Form_addRegisEmployee regEmp = new Form_addRegisEmployee();
        public Form_addRegisPosition(Form_addRegisEmployee frm) {
            InitializeComponent();
            regEmp = frm;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            PositionFunctions position = new PositionFunctions();
            position.Add(textBox_name.Text);
            regEmp.EmpUpdate();
            this.Close();
        }
    }
}
