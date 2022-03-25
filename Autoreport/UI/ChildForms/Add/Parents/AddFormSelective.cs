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
        protected Action<Mode, Button> OwnerMode_Turn;
        protected Button relatedTab;
        protected Action CloseHandler;
        protected string selectedBoxTag = "SelectedBox";

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
        protected void SelectBtn_Click(object sender, EventArgs e)
        {
            OwnerMode_Turn(Mode.Select, relatedTab);
            this.Hide();
        }

        protected void OnSelectedHandler(ListBox.ObjectCollection items)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(FlowLayoutPanel))
                {
                    foreach (Control underC in c.Controls)
                    {
                        if (underC.Tag != null && underC.Tag == selectedBoxTag)
                        {
                            foreach (GridSelectedItem item in items)
                            {
                                ((ListBox)underC).Items.Add(item);
                            }

                            OwnerMode_Turn(Mode.General, null);
                            this.ShowDialog(owner);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        protected void Form_Load(object sender, EventArgs e)
        {
            owner = (MainWindow)Owner;
            OwnerMode_Turn = owner.WindowMode(OnSelectedHandler);
        }

        protected virtual void RemoveSelectedBtn_Click(object sender, EventArgs e) { }
        protected virtual void SelectedBox_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
