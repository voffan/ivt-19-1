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
        Button filmsTab;
        Action<bool, Button> OwnerSelectModeEnabled;
        Action CloseHandler;

        public AddDiskForm(Button filmsTab, Action OnCloseHandler)
        {
            InitializeComponent();
            this.filmsTab = filmsTab;
            CloseHandler = OnCloseHandler;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (selectedFilmsBox.Items.Count == 0)
            {
                MessageBox.Show("Не выбран ни один диск", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string article = articleText.Text;
            string count = countText.Text;
            string cost = costText.Text;
            List<int> films_ids = selectedFilmsBox.Items.Cast<GridSelectedItem>()
                .Select(item => item.Id).ToList();

            Connection.diskService.Add(article, count, cost, Connection.filmService.GetByIds(films_ids));
            CloseHandler();
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
            OwnerSelectModeEnabled(true, filmsTab);
            this.Hide();
        }

        private void OnSelectedHandler(ListBox.ObjectCollection items)
        {
            foreach (GridSelectedItem item in items)
            {
                selectedFilmsBox.Items.Add(item);
            }

            OwnerSelectModeEnabled(false, null);
            this.ShowDialog(owner);
        }

        private void AddDiskForm_Load(object sender, EventArgs e)
        {
            owner = (MainWindow)Owner;
            OwnerSelectModeEnabled = owner.SelectMode(OnSelectedHandler);
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
