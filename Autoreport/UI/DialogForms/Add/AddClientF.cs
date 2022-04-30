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
    public partial class AddClientF : BaseAddForm
    {
        public AddClientF()
        {
            InitializeComponent();
            AddInputControl_ArrowKeyPressEventListener(flowLayout);

            saveBtn.Tag = this.MainButtonTag;
            AddFormEnterPressEvent(this);
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
            string phone2 = phoneAdditionalText.MaskCompleted ? phoneAdditionalText.Text : ""; // иначе phone2 добавится в таком виде: +7 ( )

            Connection.clientService.Add(lastName, firstName, middleName,
               phone1, phone2);

            Close();
        }
    }
}
