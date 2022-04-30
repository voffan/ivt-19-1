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
using Autoreport.UI.Add.Parents;

namespace Autoreport.UI.Add
{
    public partial class AddFilmDirectorF : BaseAddForm
    {
        public AddFilmDirectorF()
        {
            InitializeComponent();

            AddArrowKeyEventListener(flowLayout);

            saveBtn.Tag = this.EnterButtonTag;
            AddEnterKeyEventListener(this);
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
