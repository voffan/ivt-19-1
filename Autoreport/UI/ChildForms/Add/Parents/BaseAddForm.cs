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
    public partial class BaseAddForm : Form
    {
        public BaseAddForm()
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
            foreach (Control c in flowLayout.Controls)
            {
                if (c.GetType() == typeof(Label) || c.GetType() == typeof(Panel))
                    continue;

                if (typeof(TextBoxBase).IsAssignableFrom(c.GetType()))
                {
                    ((TextBoxBase)c).Clear();
                }
                else if (c.GetType() == typeof(ListBox))
                {
                    ((ListBox)c).Items.Clear();
                }
                else if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).Clear();
                }
            }
        }
    }
}
