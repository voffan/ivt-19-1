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
    public partial class EditClientF : BaseAddForm, IEditForm
    {
        Client editingEntity;

        public EditClientF()
        {
            InitializeComponent();
            AddArrowKeyEventListener(flowLayout);
            saveBtn.Tag = this.EnterButtonTag;
            AddEnterKeyEventListener(this);
        }

        void IEditForm.LoadField(int entityId)
        {
            editingEntity = Connection.clientService.Get(entityId);

            if (editingEntity == null)
            {
                MessageBox.Show("Такого клиента не сущесвует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lastNameText.Text = editingEntity.Last_name;
            firstNameText.Text = editingEntity.First_name;
            middleNameText.Text = editingEntity.Middle_name;
            phoneText.Text = editingEntity.Phone_number1;
            phoneAdditionalText.Text = editingEntity.Phone_number2;
            debtCountText.Value = editingEntity.Debt_count;
        }

        protected override void saveBtn_Click(object sender, EventArgs e)
        {
            foreach (Control field in GetAllBlankFields())
            {
                if (field == middleNameText || field == phoneAdditionalText)
                    continue;
                else
                {
                    MessageBox.Show("Проверьте, все ли поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string lastName = lastNameText.Text;
            string firstName = firstNameText.Text;
            string middleName = middleNameText.Text;
            string phone1 = phoneText.Text;
            string phone2 = phoneAdditionalText.MaskCompleted ? phoneAdditionalText.Text : "";
            int debtCount = (int)debtCountText.Value;

            Connection.clientService.Edit(editingEntity, lastName, firstName, middleName, phone1, phone2, debtCount);

            Close();
        }
    }
}
