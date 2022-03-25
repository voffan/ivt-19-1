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
    public partial class Form_addRAM : Form
    {
        bool Type_Add;
        int id;
        public Form_addRAM(bool Add, int index)
        {
            InitializeComponent();
            button1.Visible = Add;
            button_Edit.Visible = !Add;
            Type_Add = Add;
            id = index;
        }

        private void button2_Click(object sender, EventArgs e) //Закрытие формы
        {
            this.Close();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (!Type_Add)
            {
                using(Context c = new Context())
                {
                    /*var rams = from r in c.RAMs
                               where r.Id.Equals(id)
                               select r;*/
                    var rams = c.RAMs.Find(id);
                    textBox_name.Text = rams.Name;
                    textBox_Manufacturer.Text = rams.Manufacturer;
                    textBox_capacity.Text = rams.Capacity.ToString();
                }
                //For edit mode
            }
        }

        // При нажатии кнопки создается новый экземпляр класса и вызывается метод Add, которому передается три аргумента
        // (Наименование, производитель и обьем оперативной памяти), который добавляет в список новый элемент,
        // если все поля заполнены, в противной случае вызывает окно с ошибкой
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text.Length != 0 && textBox_Manufacturer.Text.Length != 0 && textBox_capacity.Text.Length != 0) {
                RAMFunctions RAM = new RAMFunctions();
                RAM.Add(textBox_name.Text, textBox_Manufacturer.Text, Convert.ToInt32(textBox_capacity.Text));
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
