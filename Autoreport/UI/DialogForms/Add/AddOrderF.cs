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

namespace Autoreport.UI
{
    public partial class AddOrderF : AddFormSelective
    {
        Button depositRelatedTab;
        Button disksRelatedTab;

        public AddOrderF(Button depositRelatedTab, Button disksRelatedTab, Action OnCloseHandler) : base()
        {
            InitializeComponent();

            AddInputControl_ArrowKeyPressEventListener(flowLayout);

            saveBtn.Tag = this.MainButtonTag;
            AddFormEnterPressEvent(this);

            this.Load += OrderF_Load;
            this.depositRelatedTab = depositRelatedTab;
            this.disksRelatedTab = disksRelatedTab;
            this.CloseHandler = OnCloseHandler;
        }

        protected override void saveBtn_Click(object sender, EventArgs e)
        {
            if (selectedBox_Deposit.Items.Count == 0 || selectedBox_Disks.Items.Count == 0)
            {
                MessageBox.Show("Не выбран депозит или диски", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime orderDate = orderDateText.Value;
            DateTime returnDate = returnDateText.Value;

            int deposit_id = selectedBox_Deposit.Items.Cast<GridSelectedItem>().Select(item => item.Id).ToList()[0];
            List<int> disks_ids = selectedBox_Disks.Items.Cast<GridSelectedItem>()
                .Select(item => item.Id).ToList();

            Connection.orderService.Add(orderDate, returnDate, 
                Connection.employeeService.CurrentEmployee, 
                Connection.depositService.GetById(deposit_id),
                Connection.diskService.GetByIds(disks_ids));

            CloseHandler();
            Close();
        }

        private void OrderF_Load(object sender, EventArgs e)
        {
            if (selectedBox_Deposit.Items.Count > 0 && selectedBox_Deposit.Items[0] != null)
            {
                ownerLabel.Text = selectedBox_Deposit.Items[0].ToString();
            }
        }

        protected override void RemoveSelectedBtn_Click(object sender, EventArgs e)
        {
            selectedBox_Deposit.Items.RemoveAt(selectedBox_Deposit.SelectedIndex);
        }

        protected override void SelectedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeSelectedBtn.Enabled = selectedBox_Deposit.SelectedIndex != -1;
        }

        private void selectedBox_Deposit_Click(object sender, EventArgs e)
        {
            this.relatedTab = depositRelatedTab;
            selectedBox_Deposit.Tag = selectedBoxTag;
            selectedBox_Disks.Tag = null;
            maxSelectedCount = 1;

            this.Select_Click(sender, e);
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            this.relatedTab = disksRelatedTab;
            selectedBox_Deposit.Tag = null;
            selectedBox_Disks.Tag = selectedBoxTag;
            maxSelectedCount = 100;

            this.Select_Click(sender, e);
        }
    }
}
