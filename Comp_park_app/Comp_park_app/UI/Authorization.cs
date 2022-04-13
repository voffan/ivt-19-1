using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comp_park_app_form;

namespace Comp_park_app.UI {
    public partial class Authorization : Form {
        public Authorization() {
            InitializeComponent();
        }

        Form1 main = new Form1();

        private void button_entry_Click(object sender, EventArgs e) {

            if (true) {
                Program.Context.MainForm = new Form1();
                this.Close();
                // покажет вторую форму и оставит приложение живым до ее закрытия
                Program.Context.MainForm.Show();

            }
        }

        private void button_regis_Click(object sender, EventArgs e) {
            Form_addEmployee reg = new Form_addEmployee(true, -1, main);
            reg.ShowDialog();
        }

        private void Authorization_Load(object sender, EventArgs e) {

        }
    }
}
