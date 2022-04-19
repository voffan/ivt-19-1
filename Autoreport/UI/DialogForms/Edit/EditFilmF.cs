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
using Autoreport.UI.Edit.Parents;

namespace Autoreport.UI.Edit
{
    public partial class EditFilmF : EditFormSelective
    {
        Film editingEntity;

        public EditFilmF(Button filmDirectorRelatedTab, Action OnCloseHandler) : base()
        {
            InitializeComponent();

            AddInputControl_ArrowKeyPressEventListener(flowLayout);

            saveBtn.Tag = this.MainButtonTag;
            AddFormEnterPressEvent(this);

            this.Load += new EventHandler(this.Form_Load);

            selectedBox.Tag = this.selectedBoxTag;
            this.relatedTab = filmDirectorRelatedTab;
            this.CloseHandler = OnCloseHandler;
        }

        public void AddFilmForm_Load(object sender, EventArgs e)
        {
            if (editingEntity == null)
            {
                // не был вызван LoadField с корректным айди
                MessageBox.Show("Не проинициализированы поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Loaded)
                return;

            countryBox.DataSource = Connection.filmService.GetCountries();
            countryBox.DisplayMember = "Name";
            countryBox.ValueMember = "Id";
            countryBox.SelectedValue = editingEntity.FilmCountry.Id;

            genresBox.DataSource = Connection.filmService.GetGenres();
            genresBox.DisplayMember = "Name";
            genresBox.ValueMember = "Id";

            genresBox.ClearSelected(); // первый элемент автоматически устанавливается выбранным, поэтому убираем

            for (int i = 0; i < editingEntity.Genres.Count; i++)
            {
                genresBox.SetSelected(genresBox.Items.IndexOf(genresBox.Items.Cast<object>().First(x => ((Genre)x).Id == editingEntity.Genres[i].Id)), true);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // после поочередного вызова Hide и ShowDialog у maskedtext
            // пропадают нижние подчеркивания
            //string oldText = filmDateText.Text;
            //filmDateText.Text = "0";
            //filmDateText.Text = oldText;
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

            //var selectedDirectors = Connection.filmService.GetFilmsDirectors().Where(d => directors_ids.Contains(d.Id)).ToList();

            Connection.filmService.Edit(editingEntity, filmName, filmYear, (int)countryBox.SelectedValue, directors, genresBox.SelectedItems.Cast<Genre>().ToList());
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

        public override void LoadField(int entityId)
        {
            editingEntity = Connection.filmService.Get(entityId);

            if (editingEntity == null)
            {
                MessageBox.Show("Такого фильма не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            filmNameText.Text = editingEntity.Name;
            filmYearText.Text = editingEntity.Year.ToString();
            selectedBox.Items.AddRange(editingEntity.FilmDirectors.ToArray());
        }
    }
}