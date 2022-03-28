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
    public partial class AddClientForm : BaseAddForm
    {
        public AddClientForm()
        {
            InitializeComponent();
            AddInputControl_ArrowKeyPressEventListener(flowLayout);
            AddFormEnterPressEvent(this);
        }

        protected override void saveBtn_Click(object sender, EventArgs e)
        {
            string lastName = lastNameText.Text;
            string firstName = firstNameText.Text;
            string middleName = middleNameText.Text;
            string phone1 = phoneText.Text;
            string phone2 = phoneAdditionalText.Text;

            Connection.clientService.Add(lastName, firstName, middleName,
               phone1, phone2 );

            Close();
        }
    }
}
