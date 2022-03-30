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
    public partial class AddFilmF : AddFormSelective
    {
        public AddFilmF(Button relatedTab, Action OnCloseHandler) : base()
        {
            InitializeComponent();

            AddInputControl_ArrowKeyPressEventListener(flowLayout);

            saveBtn.Tag = this.MainButtonTag;
            AddFormEnterPressEvent(this);

            this.Load += new EventHandler(this.AddFilmForm_Load);

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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // после поочередного вызова Hide и ShowDialog у maskedtext
            // пропадают нижние подчеркивания
            string oldText = filmDateText.Text;
            filmDateText.Text = "0";
            filmDateText.Text = oldText;
        }

        protected override void saveBtn_Click(object sender, EventArgs e)
        {
            if (selectedBox.Items.Count == 0)
            {
                MessageBox.Show("Не выбран режиссер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string filmName = filmNameText.Text;
            DateTime filmDate = DateTime.Parse(filmDateText.Text, new CultureInfo("de-DE"));

            List<int> directors_ids = selectedBox.Items.Cast<GridSelectedItem>()
                .Select(item => item.Id).ToList();

            var selectedDirectors = Connection.filmService.GetFilmsDirectors().Where(d => directors_ids.Contains(d.Id)).ToList();

            Connection.filmService.Add(filmName, filmDate, (Country)countryBox.SelectedItem, selectedDirectors, genresBox.SelectedItems.Cast<Genre>().ToList());
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