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
    public partial class ProductEditForm : Form
    {
        int id;
        public ProductEditForm(int index)
        {
            InitializeComponent();
            id = index;
        }

        private void ProductEditForm_Load(object sender, EventArgs e)
        {
            Product product;
            using (Context c = new Context())
            {
                product = c.Products.Find(id);
                textBox1.Text = product.Size_box;

                comboBox1.DataSource = c.Products.ToList();
                comboBox1.DisplayMember = "Type_name";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedItem = c.Typees.Find(product.TypeeId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0 &&  comboBox1.SelectedIndex >= 0 )
            {

                ProductFunctions product = new ProductFunctions();
                var size_box = Convert.ToInt32(textBox1.Text);
                var typeid = comboBox1.SelectedValue.ToString();
                product.Edit(id, size_box,typeid);
                this.Close();
            }
        }
    }
}
