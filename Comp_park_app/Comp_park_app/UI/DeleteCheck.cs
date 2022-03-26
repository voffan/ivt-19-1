using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp_park_app.UI
{
    public partial class DeleteCheck : Form
    {
        public DeleteCheck()
        {
            InitializeComponent();

            Button OkButton = new Button();
            OkButton.Text = "Да";
            OkButton.DialogResult = DialogResult.OK;
            OkButton.Location = new Point(8, 20);
            OkButton.Size = new Size(50, 24);
            this.Controls.Add(OkButton);

            Button CancelButton = new Button();
            CancelButton.Text = "Нет";
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(64, 20);
            CancelButton.Size = new Size(50, 24);
            this.Controls.Add(CancelButton);

            this.Text = "Вы уверены?";
            this.Size = new Size(130, 90);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ControlBox = false;

        }
    }
}
