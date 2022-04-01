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
    public partial class AddEmployeeF : BaseAddForm
    {
        public AddEmployeeF()
        {
            InitializeComponent();

            AddInputControl_ArrowKeyPressEventListener(flowLayout);

            saveBtn.Tag = this.MainButtonTag;
            AddFormEnterPressEvent(this);
        }

        /// <summary>
        /// Вызывается при создании окна
        /// Заполняет ComboBox positionBox значениями из Enum Position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            positionBox.DisplayMember = "Key";
            positionBox.ValueMember = "Value";
            positionBox.DataSource = new BindingSource(DescriptionAttributes<Position>.RetrieveAttributes(), null);
        }

        protected override void saveBtn_Click(object sender, EventArgs e)
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

            try
            {
                Connection.employeeService.Add(lastName, firstName, middleName,
                    passport, position, phone, login, password);
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }  
    }
}
