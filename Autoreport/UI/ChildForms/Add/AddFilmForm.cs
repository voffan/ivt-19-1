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

            selectedBox.Tag = this.selectedBoxTag;
            this.relatedTab = relatedTab;
            this.CloseHandler = OnCloseHandler;
        }

        public void AddFilmForm_Load(object sender, EventArgs e)
        {
            Country[] countries = Connection.filmService.GetCountries().ToArray();

            genresBox.Items.AddRange(Connection.filmService.GetGenres().ToArray());
            countryBox.Items.AddRange(countries);

            countryBox.SelectedItem = countries.Where(c => c.Name == "США").ToList()[0];
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
            selectedBox.Items.RemoveAt(selectedBox.SelectedIndex);

            if (selectedBox.Items.Count == 0)
                removeSelectedBtn.Enabled = false;
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

        protected override void SelectedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeSelectedBtn.Enabled = true;
        }
    }
}