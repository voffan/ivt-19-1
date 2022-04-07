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
using Comp_park_app_form;

namespace Comp_park_app
{
    public partial class Form_addDepartment : Form
    {
        bool Type_Add;
        int id;
        Form1 frm1;
        public Form_addDepartment(bool Add, int index, Form1 fr1)
        {
            InitializeComponent();
            button1.Visible = Add;
            button_Edit.Visible = !Add;
            Type_Add = Add;
            id = index;
            frm1 = fr1;
        }
        private void button2_Click(object sender, EventArgs e) //Закрытие формы
        {
            this.Close();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (!Type_Add)
            {
                Department department;
                using(Context c = new Context())
                {
                    department = c.Departments.Find(id);
                    textBox_name.Text = department.Name;
                    textBox_Manufacturer.Text = Convert.ToString(department.Number);
                }
                //For edit mode
            }
        }

        // При нажатии кнопки создается новый экземпляр класса и вызывается метод Add, которому передается три аргумента
        // (Наименование, производитель и обьем оперативной памяти), который добавляет в список новый элемент,
        // если все поля заполнены, в противной случае вызывает окно с ошибкой
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text.Length != 0 && textBox_Manufacturer.Text.Length != 0)
            {
                DepartmentFunctions Department = new DepartmentFunctions();
                Department.Add(textBox_name.Text, Convert.ToInt32(textBox_Manufacturer.Text));
                frm1.Update_datagridview(1);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text.Length != 0 && textBox_Manufacturer.Text.Length != 0)
            {
                DepartmentFunctions Department = new DepartmentFunctions();
                Department.Edit(id, textBox_name.Text, Convert.ToInt32(textBox_Manufacturer.Text));
                frm1.Update_datagridview(1);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
