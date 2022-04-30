using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using Autoreport.Services;
using Autoreport.Database;

namespace Autoreport.UI
{
    public partial class Login : BaseForm
    {
        public bool loggedIn = false;

        public Login()
        {
            InitializeComponent();
            AddArrowKeyEventListener();

            login_btn.Tag = this.EnterButtonTag;
            AddEnterKeyEventListener(this);
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string login = login_text.Text, password = password_text.Text;

            try
            {
                Connection.employeeService.Login(login, password);
                loggedIn = true;
                Close();
            } catch (Exception exc)
            {
                loggedIn = false;
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
