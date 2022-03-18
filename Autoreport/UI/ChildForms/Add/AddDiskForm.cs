using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoreport.Models;
using Autoreport.UI.Classes;
using Autoreport.Database;

namespace Autoreport.UI
{
    public partial class AddDiskForm : AddFormSelective
    {
        public AddDiskForm(Button relatedTab, Action OnCloseHandler) : base()
        {
            InitializeComponent();

            selectedBox.Tag = this.selectedBoxTag;
            this.relatedTab = relatedTab;
            this.CloseHandler = OnCloseHandler;
        }

        protected override void saveBtn_Click(object sender, EventArgs e)
        {
            if (selectedBox.Items.Count == 0)
            {
                MessageBox.Show("Не выбран ни один диск", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string article = articleText.Text;
            string count = countText.Text;
            string cost = costText.Text;
            List<int> films_ids = selectedBox.Items.Cast<GridSelectedItem>()
                .Select(item => item.Id).ToList();

            Connection.diskService.Add(article, count, cost, Connection.filmService.GetByIds(films_ids));
            CloseHandler();
            Close();
        }

        //protected override void OnSelectedHandler(ListBox.ObjectCollection items)
        //{
        //    foreach (GridSelectedItem item in items)
        //    {
        //        selectedBox.Items.Add(item);
        //    }

        //    OwnerSelectMode_Turn(SelectMode.Disabled, null);
        //    this.ShowDialog(owner);
        //}

        protected override void RemoveSelectedBtn_Click(object sender, EventArgs e)
        {
            selectedBox.Items.RemoveAt(selectedBox.SelectedIndex);

            if (selectedBox.Items.Count == 0)
                removeSelectedBtn.Enabled = false;
        }

        protected override void SelectedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeSelectedBtn.Enabled = true;
        }

        private void DigitText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
