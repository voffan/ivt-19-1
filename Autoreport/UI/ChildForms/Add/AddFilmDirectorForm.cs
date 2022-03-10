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

namespace Autoreport.UI.ChildForms.Add
{
    public partial class AddFilmDirectorForm : Form
    {
        public AddFilmDirectorForm(Button relatedTab, Action OnCloseHandler)
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
