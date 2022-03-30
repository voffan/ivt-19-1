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

namespace Autoreport.UI
{
    public partial class AddFormSelective : BaseAddForm
    {
        protected MainWindow owner;
        protected Action<Mode, Button, GridSelectedItem[]> OwnerMode_Turn;
        protected Button relatedTab;
        protected Action CloseHandler;
        protected int maxSelectedCount = 100;
        protected readonly string selectedBoxTag = "SelectedBox";
        private bool Loaded = false;

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
            OwnerMode_Turn(Mode.Select, relatedTab, GetSelectedListBox().Items.Cast<GridSelectedItem>().ToArray());
            this.Hide();
        }

        protected void OnSelectedHandler(ListBox.ObjectCollection items)
        {
            Console.WriteLine("Call from {0}", this.Name);
            ListBox listBox = GetSelectedListBox();

            // очистка листбокса от старых записей, т.к. они все равно копируются в селектбокс мэйнвиндоу
            listBox.Items.Clear();

            if (items.Count > maxSelectedCount)
            {
                MessageBox.Show(String.Format("Количество выбранных записей({0}) превысило максимальное({1})", items.Count, maxSelectedCount),
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (GridSelectedItem item in items)
            {
                listBox.Items.Add(item);
            }

            OwnerMode_Turn(Mode.General, null, null);
            this.ShowDialog(owner);
        }

        private ListBox GetSelectedListBox()
        {
            foreach (Control c in GetPanels())
            {
                foreach (Control underC in c.Controls)
                {
                    if (underC.Tag != null && underC.Tag == selectedBoxTag)
                    {
                        return (ListBox)underC;
                    }
                }
                break;
            }

            return null;
        }

        protected void Form_Load(object sender, EventArgs e)
        {
            owner = (MainWindow)Owner;
            
            if (!Loaded)
                OwnerMode_Turn = owner.WindowMode(OnSelectedHandler);

            Loaded = true;
        }

        protected virtual void RemoveSelectedBtn_Click(object sender, EventArgs e) { }
        protected virtual void SelectedBox_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
