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
using Autoreport.UI.Edit.Parents;
using Autoreport.UI.Add.Parents;

namespace Autoreport.UI.Edit
{
    public partial class EditDiskF : AddFormSelective, IEditForm
    {
        Disk editingEntity;
        Button thisrelatedTab;
        public EditDiskF(Button relatedTab, Action OnCloseHandler) : base()
        {
            InitializeComponent();

            AddArrowKeyEventListener(flowLayout);

            this.Load += new EventHandler(Form_Load);

            saveBtn.Tag = this.EnterButtonTag;
            AddEnterKeyEventListener(this);

            selectedBox.Tag = this.selectedBoxTag;
            this.thisrelatedTab = relatedTab;
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
            List<Film> films = selectedBox.Items.Cast<Film>().ToList();
            Connection.diskService.Edit(editingEntity, article, count, cost, films);
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

        private void DigitText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void LoadField(int entityId)
        {
            editingEntity = Connection.diskService.Get(entityId);
            if (editingEntity == null)
            {
                MessageBox.Show("Такого диска не сущесвует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            selectedBox.Items.AddRange(editingEntity.Films.ToArray());            
            articleText.Text = editingEntity.Article;
            countText.Text = Convert.ToString(editingEntity.General_count);
            costText.Text = Convert.ToString(editingEntity.Cost);

        }
    }
}
