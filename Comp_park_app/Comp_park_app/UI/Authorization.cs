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
                var b = c.Employees.FirstOrDefault(e => e.Name == textBox_Login.Text);
                bool prov = EmployeeFunctions.VerifyHashedPassword(b.Password, textBox_Password.Text);
                label3.Text = b.Password;
                label4.Text = Convert.ToString(prov);
                if (b != null && prov)
                {
                    Program.Context.MainForm = new Form1();
                    this.Close();
                    // покажет вторую форму и оставит приложение живым до ее закрытия
                    Program.Context.MainForm.Show();

                }else { 

                }
            }
        }

        private void button_regis_Click(object sender, EventArgs e) {
            Form_addRegisEmployee reg = new Form_addRegisEmployee();
            reg.ShowDialog();
        }

        private void Authorization_Load(object sender, EventArgs e) {

        }
    }
}
