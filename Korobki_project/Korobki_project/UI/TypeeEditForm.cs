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
    public partial class TypeeEditForm : Form
    {
        int id;
        public TypeeEditForm(int index)
        {
            InitializeComponent();
            id = index;
        }

        private void TypeeEditForm_Load(object sender, EventArgs e)
        {
            Typee typee;
            using (Context c = new Context())
            {
                typee = c.Typees.Find(id);
                textBox1.Text = typee.Type_name.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
            {

                TypeeFunctions typee = new TypeeFunctions();
                var type_name = textBox1.Text;
                typee.Edit(id, type_name);
                this.Close();
            }
            else MessageBox.Show("Ошибка заполните все поля");
        }
    }
}
