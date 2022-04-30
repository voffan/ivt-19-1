using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoreport.UI.Edit.Parents
{
    interface IEditForm
    {
        public void LoadField(int entityId);
        public DialogResult ShowDialog(IWin32Window owner);
    }
}
