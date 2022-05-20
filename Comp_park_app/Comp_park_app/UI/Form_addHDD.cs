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

namespace Comp_park_app {
    public partial class Form_addHDD : Form {
        bool Type_Add;
        int id;
        Form1 frm1;
        public Form_addHDD(bool Add, int index, Form1 fr1) {
            InitializeComponent();
            button1.Visible = Add;
            button_Edit.Visible = !Add;
            Type_Add = Add;
            id = index;
            frm1 = fr1;
        }

        //Закрытие формы
        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Form_Load(object sender, EventArgs e) {
            if (!Type_Add) {
                HDD hdd;
                using(Context c = new Context()) {
                    hdd = c.HDDs.Find(id);
                    textBox_name.Text = hdd.Name;
                    textBox_Manufacturer.Text = hdd.Manufacturer;
                    numericUpDown_capacity.Value = hdd.Capacity;
                }
                //For edit mode
            }
        }

        // При нажатии кнопки создается новый экземпляр класса и вызывается метод Add, которому передается три аргумента
        // (Наименование, производитель и обьем оперативной памяти), который добавляет в список новый элемент,
        // если все поля заполнены, в противной случае вызывает окно с ошибкой
        private void button1_Click(object sender, EventArgs e) {
            if (textBox_name.Text.Length != 0 && textBox_Manufacturer.Text.Length != 0 && numericUpDown_capacity.Value > 0) {
                HDDFunctions HDD = new HDDFunctions();
                HDD.Add(textBox_name.Text, textBox_Manufacturer.Text, (int)numericUpDown_capacity.Value);
                frm1.Update_datagridview(3);
                this.Close();
            } else {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void button_Edit_Click(object sender, EventArgs e) {
            if (textBox_name.Text.Length != 0 && textBox_Manufacturer.Text.Length != 0 && numericUpDown_capacity.Value > 0) {
                HDDFunctions HDD = new HDDFunctions();
                HDD.Edit(id, textBox_name.Text, textBox_Manufacturer.Text, (int)numericUpDown_capacity.Value);
                frm1.Update_datagridview(3);
                this.Close();
            } else {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }
}
