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

namespace Autoreport.UI.Edit
{
    public partial class EditClientF : BaseEditForm
    {
        Client editingEntity;
        public EditClientF()
        {
            InitializeComponent();
            AddInputControl_ArrowKeyPressEventListener(flowLayout);
            saveBtn.Tag = this.MainButtonTag;
            AddFormEnterPressEvent(this);
        }

        public override void LoadField(int entityId)
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
        }

        protected override void saveBtn_Click(object sender, EventArgs e)
        {
            bool phoneAdditionalNotFilled = false;

            foreach (Control field in GetAllBlankFields())
            {
                if (field == middleNameText)
                    continue;
                else if (field == phoneAdditionalText)
                {
                    phoneAdditionalNotFilled = true;
                    continue;
                }
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

            string phone2;

            if (phoneAdditionalNotFilled) // иначе phone2 добавится в таком виде: +7 ( )
                phone2 = phoneAdditionalText.Text;
            else
                phone2 = "";

            Connection.clientService.Edit(editingEntity,lastName,firstName,middleName,phone1,phone2);

            Close();
        }
    }
}
