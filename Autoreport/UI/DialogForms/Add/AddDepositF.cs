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

namespace Autoreport.UI
{
    public partial class AddDepositF : AddFormSelective
    {
        public AddDepositF(Button relatedTab, Action OnCloseHandler) : base()
        {
            base.maxSelectedCount = 1;

            InitializeComponent();
            AddInputControl_ArrowKeyPressEventListener(flowLayout);

            saveBtn.Tag = this.MainButtonTag;
            AddFormEnterPressEvent(this);

            this.Load += new EventHandler(this.Form_Load);

            selectedBox.Tag = this.selectedBoxTag;
            this.relatedTab = relatedTab;
            this.CloseHandler = OnCloseHandler;
        }

        private void AddDepositForm_Load(object sender, EventArgs e)
        {
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
            int sum = Convert.ToInt32(sumText.Text);

            DepositType position = (DepositType)Enum.Parse(typeof(DepositType),
                positionDepositBox.SelectedValue.ToString());

            int client_id = selectedBox.Items.Cast<GridSelectedItem>()
                .Select(item => item.Id).ToList()[0];

            Connection.depositService.Add(data, sum, position, Connection.clientService.GetById(client_id));
            CloseHandler();
            Close();
        }
    }
}
