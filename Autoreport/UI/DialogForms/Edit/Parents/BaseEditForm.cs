using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoreport.UI.Add.Parents;

namespace Autoreport.UI.Edit.Parents
{
    public partial class BaseEditForm : BaseAddForm
    {
        public BaseEditForm() : base()
        {
            InitializeComponent();
        }

        public virtual void LoadField(int entityId) { }
    }
}
