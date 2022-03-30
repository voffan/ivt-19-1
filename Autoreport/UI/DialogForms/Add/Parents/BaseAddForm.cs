using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoreport.UI
{
    public partial class BaseAddForm : BaseForm
    {
        public BaseAddForm() : base()
        {
            InitializeComponent();
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
            foreach (Panel panel in GetAllPanels(this))
            {
                foreach (Control inputControl in GetPanelInputControls(panel))
                {
                    if (typeof(TextBoxBase).IsAssignableFrom(inputControl.GetType()))
                    {
                        ((TextBoxBase)inputControl).Clear();
                    }
                    else if (inputControl is ListBox)
                    {
                        ((ListBox)inputControl).Items.Clear();
                    }
                }
            }
        }
    }
}
