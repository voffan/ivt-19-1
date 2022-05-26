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
using Autoreport.UI;
using Autoreport.UI.Edit.Parents;
using Autoreport.UI.Add.Parents;

namespace Autoreport.UI.Edit
{
    public partial class EditDepositF : BaseAddForm, IEditForm
    {
        Deposit editingEntity;
        public EditDepositF(Button relatedTab, Action OnCloseHandler) : base()
        {
            InitializeComponent();
            AddArrowKeyEventListener(flowLayout);
            saveBtn.Tag = this.EnterButtonTag;
            AddEnterKeyEventListener(this);
        }

        private void AddDepositForm_Load(object sender, EventArgs e)
        {
            positionDepositBox.DisplayMember = "Key";
            positionDepositBox.ValueMember = "Value";
            positionDepositBox.DataSource = new BindingSource(DescriptionAttributes<DepositType>.RetrieveAttributes(), null);
            positionDepositBox.SelectedValue = editingEntity.DepositType.ToString();
        }

        protected override void saveBtn_Click(object sender, EventArgs e)
        {
            string data = dataText.Text;
            uint sum = Convert.ToUInt32(sumText.Text);

            DepositType position = (DepositType)Enum.Parse(typeof(DepositType),
                positionDepositBox.SelectedValue.ToString());

            Connection.depositService.Edit(editingEntity,data, sum, position);
            Close();
        }

        public void LoadField(int entityId)
        {
            editingEntity = Connection.depositService.Get(entityId);
            if (editingEntity == null)
            {
                MessageBox.Show("Такого залога не сущесвует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataText.Text = editingEntity.DocumentData;
            sumText.Text = Convert.ToString(editingEntity.MoneyValue);
        }
    }
}
