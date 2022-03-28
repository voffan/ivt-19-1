using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoreport.UI.Classes;
using Autoreport.Database;

namespace Autoreport.UI
{
    public partial class AddFilmDirectorForm : BaseAddForm
    {
        public AddFilmDirectorForm()
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

            Connection.filmService.AddDirector(lastName, firstName, middleName);

            Close();
        }
    }
}
