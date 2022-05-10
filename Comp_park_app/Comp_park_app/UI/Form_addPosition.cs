using Comp_park_app.Functions;
using Comp_park_app_form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp_park_app.UI {
    public partial class Form_addPosition : Form {
        bool Type_Add;
        int id;
        Form1 frm1;
        public Form_addPosition(bool Add, int index, Form1 fr1) {
            InitializeComponent();
            buttonAdd.Visible = Add;
            buttonEdit.Visible = !Add;
            Type_Add = Add;
            id = index;
            frm1 = fr1;
        }

        //Закрытие формы
        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        //Добавление должности
        private void button_Edit_Click(object sender, EventArgs e) {
            if (textBox_name.Text.Length != 0) {
                PositionFunctions position = new PositionFunctions();
                position.Add(textBox_name.Text);
                frm1.Update_datagridview(8);
                this.Close();
            } else {
                MessageBox.Show("Error");
            }
        }

        //Изменение должности
        private void buttonEdit_Click(object sender, EventArgs e) {
            if (textBox_name.Text.Length != 0) {
                PositionFunctions position = new PositionFunctions();
                position.Edit(id, textBox_name.Text);
                frm1.Update_datagridview(8);
                this.Close();
            } else {
                MessageBox.Show("Error");
            }
        }

        private void Form_addPosition_Load(object sender, EventArgs e) {
            
            if (!Type_Add) {
                buttonEdit.Location = new System.Drawing.Point(70, 174);
                //buttonEdit.Visible = true;
                Position position;
                using (Context c = new Context()) {
                    position = c.Positions.Find(id);
                    textBox_name.Text = position.Name;
                }
                //For edit mode
            }
        }
    }
}
