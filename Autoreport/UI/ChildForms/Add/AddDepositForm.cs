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
    public partial class AddDepositForm : AddFormSelective
    {
        /*Button relatedTab, Action OnCloseHandler*/   /*: base()*/
        public AddDepositForm(Button relatedTab, Action OnCloseHandler) : base()
        {
            InitializeComponent();
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

            int clients_ids = selectedBox.Items.Cast<GridSelectedItem>()
                .Select(item => item.Id).ToList()[0];

            Connection.depositService.Add(data,sum,position,Connection.clientService.GetById(clients_ids));
            CloseHandler();
            Close();
        }

        private void removeSelectedBtn_Click(object sender, EventArgs e)
        {
            selectedBox.Items.RemoveAt(selectedBox.SelectedIndex);

            if (selectedBox.Items.Count == 0)
                removeSelectedBtn.Enabled = false;
        }

        private void selectedClientsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeSelectedBtn.Enabled = true;
        }

        /*private void sumText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }*/


    }
}
