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
using Autoreport.UI.Add.Parents;

namespace Autoreport.UI.Add
{
    public partial class AddOrderF : AddFormSelective
    {
        Button depositRelatedTab;
        Button disksRelatedTab;

        public AddOrderF(Button depositRelatedTab, Button disksRelatedTab, Action OnCloseHandler) : base()
        {
            InitializeComponent();

            AddArrowKeyEventListener(flowLayout);

            saveBtn.Tag = this.EnterButtonTag;
            AddEnterKeyEventListener(this);

            this.Load += Form_Load;

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

            Deposit deposit = selectedBox_Deposit.Items.Cast<Deposit>().ToList()[0];
            List<Disk> disks = selectedBox_Disks.Items.Cast<Disk>().ToList();

            Connection.orderService.Add(orderDate, returnDate, 
                Connection.employeeService.CurrentEmployee,
                deposit, disks);

            CloseHandler();
            Close();
        }

        private void OrderF_Load(object sender, EventArgs e)
        {
            if (selectedBox_Deposit.Items.Count > 0)
            {
                ownerLabel.Text = ((Deposit)selectedBox_Deposit.Items[0]).Owner.ToString();
            }

            if (selectedBox_Disks.Items.Count > 0)
            {
                costLabel.Text = selectedBox_Disks.Items.Cast<Disk>().Sum(i => i.Cost).ToString();
            } else
            {
                costLabel.Text = "0";
            }
        }

        protected override void RemoveSelectedBtn_Click(object sender, EventArgs e)
        {
            selectedBox_Deposit.Items.RemoveAt(selectedBox_Deposit.SelectedIndex);
        }

        protected override void SelectedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeSelectedBtn.Enabled = selectedBox_Disks.SelectedIndex != -1;
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
