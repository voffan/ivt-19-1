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
using Autoreport.UI.Edit.Parents;
using Autoreport.UI.Add.Parents;

namespace Autoreport.UI.Edit
{
    public partial class EditEmployeeF : BaseAddForm, IEditForm
    {
        Employee editingEntity;

        public EditEmployeeF()
        {
            InitializeComponent();

            saveBtn.Tag = this.EnterButtonTag;

            AddArrowKeyEventListener(flowLayout);
            AddEnterKeyEventListener(this);
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
                Connection.employeeService.Edit(editingEntity, lastName, firstName, middleName,
                    passport, position, phone, login, password);
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadField(int empl_id)
        {
            editingEntity = Connection.employeeService.Get(empl_id);

            if (editingEntity == null)
            {
                MessageBox.Show("Такого клиента не сущесвует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lastNameText.Text = editingEntity.Last_name;
            firstNameText.Text = editingEntity.First_name;
            middleNameText.Text = editingEntity.Middle_name;
            passportText.AppendText(editingEntity.Passport_serial.ToString() + editingEntity.Passport_number.ToString());
            phoneText.Text = editingEntity.Phone_number;
            loginText.Text = editingEntity.Login;
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            if (editingEntity == null)
            {
                // не был вызван LoadField с корректным айди
                MessageBox.Show("Не проинициализированы поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            positionBox.DisplayMember = "Key";
            positionBox.ValueMember = "Value";
            positionBox.DataSource = new BindingSource(DescriptionAttributes<Position>.RetrieveAttributes(), null);
            positionBox.SelectedValue = editingEntity.EmplPosition.ToString();
        }
    }
}
