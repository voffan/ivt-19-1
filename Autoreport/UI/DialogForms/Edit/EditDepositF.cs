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
    public partial class EditDepositF : AddFormSelective, IEditForm
    {
        public EditDepositF(Button relatedTab, Action OnCloseHandler) : base()
        {
            base.maxSelectedCount = 1;

            InitializeComponent();
            AddArrowKeyEventListener(flowLayout);

            saveBtn.Tag = this.EnterButtonTag;
            AddEnterKeyEventListener(this);

            this.Load += new EventHandler(Form_Load);

            selectedBox.Tag = this.selectedBoxTag;
            this.relatedTab = relatedTab;
            this.CloseHandler = OnCloseHandler;
        }

        private void AddDepositForm_Load(object sender, EventArgs e)
        {
            if (Loaded)
                return;

            positionDepositBox.DisplayMember = "Key";
            positionDepositBox.ValueMember = "Value";
            positionDepositBox.DataSource = new BindingSource(DescriptionAttributes<DepositType>.RetrieveAttributes(), null);
        }

        protected override void saveBtn_Click(object sender, EventArgs e)
        {
            if (selectedBox.Items.Count == 0)
            {
                MessageBox.Show("Не выбран ни один диск", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string data = dataText.Text;
            uint sum = Convert.ToUInt32(sumText.Text);

            DepositType position = (DepositType)Enum.Parse(typeof(DepositType),
                positionDepositBox.SelectedValue.ToString());

            Client client_id = selectedBox.Items.Cast<Client>().ToList()[0];

            Connection.depositService.Add(data, sum, position, client_id);
            CloseHandler();
            Close();
        }

        public void LoadField(int entityId)
        {
            throw new NotImplementedException();
        }
    }
}
