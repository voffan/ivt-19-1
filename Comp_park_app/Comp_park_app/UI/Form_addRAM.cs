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
    public partial class Form_addRAM : Form {
        bool Type_Add;
        int id;
        Form1 frm1;
        public Form_addRAM(bool Add, int index, Form1 fr1) {
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
                using(Context c = new Context()) {
                    var rams = c.RAMs.Find(id);
                    textBox_name.Text = rams.Name;
                    textBox_Manufacturer.Text = rams.Manufacturer;
                    numericUpDown_capacity.Value = rams.Capacity;
                }
                //For edit mode
            }
        }

        // При нажатии кнопки создается новый экземпляр класса и вызывается метод Add, которому передается три аргумента
        // (Наименование, производитель и обьем оперативной памяти), который добавляет в список новый элемент,
        // если все поля заполнены, в противной случае вызывает окно с ошибкой
        private void button1_Click(object sender, EventArgs e) {
            if (textBox_name.Text.Length != 0 && textBox_Manufacturer.Text.Length != 0 && numericUpDown_capacity.Value > 0) {
                RAMFunctions RAM = new RAMFunctions();
                RAM.Add(textBox_name.Text, textBox_Manufacturer.Text, (int)numericUpDown_capacity.Value);
                frm1.Update_datagridview(7);
                this.Close();
            } else {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void button_Edit_Click(object sender, EventArgs e) {
            if (textBox_name.Text.Length != 0 && textBox_Manufacturer.Text.Length != 0 && numericUpDown_capacity.Value > 0) {
                RAMFunctions RAM = new RAMFunctions();
                RAM.Edit(id, textBox_name.Text, textBox_Manufacturer.Text, (int)numericUpDown_capacity.Value);
                frm1.Update_datagridview(7);
                this.Close();
            } else {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }
}
