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
    public partial class Form_addDepartment : Form
    {
        public Form_addDepartment()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e) //Закрытие формы
        {
            this.Close();
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
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
