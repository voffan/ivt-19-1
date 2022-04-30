using Autoreport.UI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoreport.UI.Add.Parents
{
    public partial class AddFormSelective : BaseAddForm
    {
        protected MainF owner;
        protected Action<Mode, Button, object[]> OwnerMode_Turn;
        protected Button relatedTab;
        protected Action CloseHandler;
        protected int maxSelectedCount = 100;
        protected bool Loaded = false;
        protected readonly string selectedBoxTag = "SelectedBox";

        public AddFormSelective()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Реакция на нажатие кнопки "Выбрать"
        /// Переключает главное окно в режим выбора данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Select_Click(object sender, EventArgs e)
        {
            Console.WriteLine("{0} enabling select mode", this.Name);
            OwnerMode_Turn(Mode.Select, relatedTab, GetSelectedListBox().Items.Cast<object>().ToArray());
            this.Hide();
        }

        protected void OnSelectedHandler(ListBox.ObjectCollection items)
        {
            ListBox listBox = GetSelectedListBox();

            // очистка листбокса от старых записей, т.к. они все равно копируются в селектбокс мэйнвиндоу
            listBox.Items.Clear();

            if (items.Count > maxSelectedCount)
            {
                MessageBox.Show(String.Format("Количество выбранных записей({0}) превысило максимальное({1})", items.Count, maxSelectedCount),
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (object item in items)
            {
                listBox.Items.Add(item);
            }

            Console.WriteLine("{0} disabling select mode", this.Name);
            OwnerMode_Turn(Mode.General, null, null);
            this.ShowDialog(owner);
        }

        protected ListBox GetSelectedListBox()
        {
            foreach (Control panel in GetAllPanels(this))
            {
                foreach (Control control in panel.Controls)
                {
                    if (control.Tag != null && (string)control.Tag == selectedBoxTag)
                    {
                        return (ListBox)control;
                    }
                }
            }

            return null;
        }

        protected void Form_Load(object sender, EventArgs e)
        {
            owner = (MainF)Owner;

            if (!Loaded)
            {
                OwnerMode_Turn = owner.WindowMode(OnSelectedHandler);
            }

            Loaded = true;
        }

        protected virtual void RemoveSelectedBtn_Click(object sender, EventArgs e) { }
        protected virtual void SelectedBox_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
