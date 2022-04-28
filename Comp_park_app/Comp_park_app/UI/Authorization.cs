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
using Comp_park_app.Functions;

namespace Comp_park_app.UI {
    public partial class Authorization : Form {
        public Authorization() {
            InitializeComponent();
        }

        private void button_entry_Click(object sender, EventArgs e) {
            //EmployeeFunctions aut = new EmployeeFunctions();
            using (Context c = new Context()) {
                if (textBox_Login.Text.Length > 0 && textBox_Password.Text.Length > 0) {
                    bool prov = EmployeeFunctions.VerifyHashedPassword(textBox_Login.Text, textBox_Password.Text);
                    if (prov) {
                        Program.Context.MainForm = new Form1();
                        this.Close();
                        // покажет вторую форму и оставит приложение живым до ее закрытия
                        Program.Context.MainForm.Show();
                    }
                } else {
                    MessageBox.Show("Логин и/или пароль не заполнены");
                }
            }
        }

        private void button_regis_Click(object sender, EventArgs e) {
            Form_addRegisEmployee reg = new Form_addRegisEmployee();
            reg.ShowDialog();
        }

        private void Authorization_Load(object sender, EventArgs e) {

        }

        private void button_exit_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
