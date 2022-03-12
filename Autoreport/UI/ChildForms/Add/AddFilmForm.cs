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
using System.Globalization;

namespace Autoreport.UI
{
    public partial class AddFilmForm : AddFormSelective
    {
        public AddFilmForm(Button relatedTab, Action OnCloseHandler) : base()
        {
            InitializeComponent();

            this.relatedTab = relatedTab;
            this.CloseHandler = OnCloseHandler;
        }

        protected override void saveBtn_Click(object sender, EventArgs e)
        {
            //if (selectedDirectorsBox.Items.Count == 0)
            //{
            //    MessageBox.Show("Не выбран ни один режиссер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            string filmName = filmNameText.Text;
            DateTime filmDate = DateTime.Parse(filmDateText.Text, new CultureInfo("de-DE"));

            //List<int> directors_ids = selectedDirectorsBox.Items.Cast<GridSelectedItem>()
            //    .Select(item => item.Id).ToList();

            Connection.filmService.Add(filmName, filmDate);
            CloseHandler();
            Close();
        }

        protected override void RemoveSelectedBtn_Click(object sender, EventArgs e)
        {
            selectedDirectorsBox.Items.RemoveAt(selectedDirectorsBox.SelectedIndex);

            if (selectedDirectorsBox.Items.Count == 0)
                removeSelectedBtn.Enabled = false;
        }

        protected override void OnSelectedHandler(ListBox.ObjectCollection items)
        {
            foreach (GridSelectedItem item in items)
            {
                selectedDirectorsBox.Items.Add(item);
            }

            OwnerSelectMode_Turn(false, null);
            this.ShowDialog(owner);
        }

        protected override void SelectedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeSelectedBtn.Enabled = true;
        }
    }
}