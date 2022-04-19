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
using Autoreport.UI.Add.Parents;

namespace Autoreport.UI.Add
{
    public partial class AddFilmF : AddFormSelective
    {
        public AddFilmF(Button relatedTab, Action OnCloseHandler) : base()
        {
            InitializeComponent();

            AddInputControl_ArrowKeyPressEventListener(flowLayout);

            saveBtn.Tag = this.MainButtonTag;
            AddFormEnterPressEvent(this);

            this.Load += new EventHandler(this.Form_Load);

            selectedBox.Tag = this.selectedBoxTag;
            this.relatedTab = relatedTab;
            this.CloseHandler = OnCloseHandler;
        }

        public void AddFilmForm_Load(object sender, EventArgs e)
        {
            if (Loaded)
                return;

            Country[] countries = Connection.filmService.GetCountries().ToArray();

            genresBox.Items.AddRange(Connection.filmService.GetGenres().ToArray());
            countryBox.Items.AddRange(countries);

            countryBox.SelectedItem = countries.Where(c => c.Name == "США").ToList()[0];
        }

        protected override void saveBtn_Click(object sender, EventArgs e)
        {
            if (selectedBox.Items.Count == 0)
            {
                MessageBox.Show("Не выбран режиссер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string filmName = filmNameText.Text;
            int filmYear = Int32.Parse(filmYearText.Text);

            List<Person> directors = selectedBox.Items.Cast<Person>().ToList();

            Connection.filmService.Add(filmName, filmYear, (Country)countryBox.SelectedItem, directors, genresBox.SelectedItems.Cast<Genre>().ToList());
            CloseHandler();
            Close();
        }

        protected override void RemoveSelectedBtn_Click(object sender, EventArgs e)
        {
            selectedBox.Items.RemoveAt(selectedBox.SelectedIndex);
        }

        protected override void SelectedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeSelectedBtn.Enabled = selectedBox.SelectedIndex != -1;
        }
    }
}