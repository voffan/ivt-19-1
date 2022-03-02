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
    public partial class AddDiskForm : Form
    {
        MainWindow owner;
        Button ownerTabButton;

        public AddDiskForm()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (selectedFilmsBox.Items.Count == 0)
            {
                MessageBox.Show("Не выбран ни один диск", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Connection.diskService.Add(articleText.Text, countText.Text, costText.Text, selectedFilmsBox.Items);

            Close();
        }

        private void RemoveSelectedBtn_Click(object sender, EventArgs e)
        {
            selectedFilmsBox.Items.RemoveAt(selectedFilmsBox.SelectedIndex);

            if (selectedFilmsBox.Items.Count == 0)
                removeSelectedBtn.Enabled = false;
        }

        private void SelectFilmsBtn_Click(object sender, EventArgs e)
        {
            // т.к. DisableAllTabsExcept переключит основное окно на другую вкладку
            // то запоминает текущую вкладку, чтоб потом ее активировать
            ownerTabButton = owner.GetCurrentTab();

            owner.SetSelectionActive(true);
            owner.DisableAllTabsExcept(owner.filmsBtn);
            owner.ConnectSelectButton(OnSelectedHandler);

            this.Hide();
        }

        private void OnSelectedHandler(ListBox.ObjectCollection items)
        {
            owner.SetSelectionActive(false);
            owner.EnableAllTabs();
            owner.RemoveSelectConnection();

            foreach (GridSelectedItem item in items)
            {
                selectedFilmsBox.Items.Add(item);
            }

            ownerTabButton.PerformClick();
            this.ShowDialog(owner);
        }

        private void AddDiskForm_Load(object sender, EventArgs e)
        {
            owner = (MainWindow)Owner;
        }

        private void SelectedFilmsBox_SelectedIndexChanged(object sender, EventArgs e)
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
