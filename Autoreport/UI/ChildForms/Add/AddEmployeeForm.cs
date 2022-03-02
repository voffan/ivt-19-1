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
    public partial class AddEmployeeForm : Form
    {
        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            positionBox.DisplayMember = "Key";
            positionBox.ValueMember = "Value";
            positionBox.DataSource = new BindingSource(DescriptionAttributes<Position>.RetrieveAttributes(), null);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string lastName = lastNameText.Text;
            string firstName = firstNameText.Text;
            string middleName = middleNameText.Text;
            string passport = passportText.Text;
            Position position = (Position)Enum.Parse(typeof(Position),
                positionBox.SelectedValue.ToString());
            string phone = phoneText.Text;
            string login = loginText.Text;
            string password = passwordText.Text;

            Connection.employeerService.Add(lastName, firstName, middleName,
                passport, position, phone, login, password);

            Close();
        }
    }
}
