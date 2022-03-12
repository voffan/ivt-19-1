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
        protected Action<bool, Button> OwnerSelectMode_Turn;
        protected Button relatedTab;
        protected Action CloseHandler;

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
            OwnerSelectMode_Turn(true, relatedTab);
            this.Hide();
        }

        protected void Form_Load(object sender, EventArgs e)
        {
            owner = (MainWindow)Owner;
            OwnerSelectMode_Turn = owner.SelectMode(OnSelectedHandler);
        }

        protected virtual void RemoveSelectedBtn_Click(object sender, EventArgs e) { }
        protected virtual void OnSelectedHandler(ListBox.ObjectCollection items) { }
        protected virtual void SelectedBox_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
