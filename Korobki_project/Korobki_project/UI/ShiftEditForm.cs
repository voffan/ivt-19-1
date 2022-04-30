using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Korobki_project.Classes;
using Korobki_project.Functions;

namespace Korobki_project.UI
{
    public partial class ShiftEditForm : Form
    {
        int id;
        public ShiftEditForm(int index)
        {
            InitializeComponent();
            id = index;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
            {

                ShiftFunctions shift = new ShiftFunctions();
                var name = textBox1.Text;
                shift.Edit(id, name);
                this.Close();
            }
            else MessageBox.Show("Ошибка заполните все поля");
        }

        private void ShiftEditForm_Load(object sender, EventArgs e)
        {
            Shift shift;
            using (Context c = new Context())
            {
                shift = c.Shifts.Find(id);
                textBox1.Text = shift.Name.ToString();
            }
        }
    }
}
