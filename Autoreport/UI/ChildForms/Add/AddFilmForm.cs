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
    public partial class AddFilmForm : Form
    {
        MainWindow owner;
        Button relatedTab;

        Action<bool, Button> OwnerSelectMode_Turn;
        Action CloseHandler;

        public AddFilmForm(Button relatedTab, Action OnCloseHandler)
        {
            InitializeComponent();
            this.relatedTab = relatedTab;
            CloseHandler = OnCloseHandler;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (selectedDirectorsBox.Items.Count == 0)
            {
                MessageBox.Show("Не выбран ни один режиссер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string filmName = filmNameText.Text;
            string filmYear = filmYearText.Text;
            List<int> directors_ids = selectedDirectorsBox.Items.Cast<GridSelectedItem>()
                .Select(item => item.Id).ToList();

            Connection.filmService.Add(filmName, filmYear);
            CloseHandler();
            Close();
        }

        private void RemoveSelectedBtn_Click(object sender, EventArgs e)
        {
            selectedDirectorsBox.Items.RemoveAt(selectedDirectorsBox.SelectedIndex);

            if (selectedDirectorsBox.Items.Count == 0)
                removeSelectedBtn.Enabled = false;
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            OwnerSelectMode_Turn(true, relatedTab);
            this.Hide();
        }

        private void OnSelectedHandler(ListBox.ObjectCollection items)
        {
            foreach (GridSelectedItem item in items)
            {
                selectedDirectorsBox.Items.Add(item);
            }

            OwnerSelectMode_Turn(false, null);
            this.ShowDialog(owner);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            owner = (MainWindow)Owner;
            OwnerSelectMode_Turn = owner.SelectMode(OnSelectedHandler);
        }

        private void SelectedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeSelectedBtn.Enabled = true;
        }
    }
}