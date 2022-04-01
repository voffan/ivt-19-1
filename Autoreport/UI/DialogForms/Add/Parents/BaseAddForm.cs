using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoreport.UI.Add.Parents
{
    public partial class BaseAddForm : BaseForm
    {
        public BaseAddForm() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Возвращает все поля для ввода
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<Control> GetAllFields()
        {
            foreach (Panel panel in GetAllPanels(this))
            {
                foreach (Control inputControl in GetPanelInputControls(panel))
                {
                    yield return inputControl;
                }
            }
        }

        /// <summary>
        /// Возвращает true, если нет ни одного пустого поля для ввода
        /// </summary>
        /// <returns></returns>
        protected bool AllFieldsNotEmpty()
        {
            foreach (Control field in GetAllFields())
            {
                if (FieldIsEmpty(field))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Возвращает все незаполненные поля, в т.ч. MaskedTextBox'ы, в которых условие маски не выполнено
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<Control> GetAllBlankFields()
        {
            foreach (Control field in GetAllFields())
            {
                if (FieldIsEmpty(field) || (field is MaskedTextBox && !((MaskedTextBox)field).MaskCompleted))
                    yield return field;
            }
        }

        /// <summary>
        /// Вызывает метод, сохраняющий данные из формы в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void saveBtn_Click(object sender, EventArgs e) { }

        /// <summary>
        /// Стирает все значения компонентов формы для ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void resetBtn_Click(object sender, EventArgs e)
        {
            foreach (Control inputControl in GetAllFields())
            {
                ClearField(inputControl);
            }
        }
    }
}
