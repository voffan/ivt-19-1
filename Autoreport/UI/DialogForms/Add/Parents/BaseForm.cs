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
    public partial class BaseForm : Form
    {
        protected string MainButtonTag = "MainButton"; // тэг для таких кнопок как "Сохранить"/"Войти" и т.д.

        public BaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Возвращает текстовые поля, либо листбоксы, хранящиеся внутри переданной панели
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected IEnumerable<Control> GetPanelInputControls(Panel p)
        {
            foreach (Control underC in p.Controls)
            {
                if (underC is Label || underC is Panel)
                    continue;

                if (typeof(TextBoxBase).IsAssignableFrom(underC.GetType()) || underC is ListBox) 
                {
                    yield return underC;
                }
            }
        }

        /// <summary>
        /// Возвращает все панели внутри переданного Control
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<Panel> GetAllPanels(Control control)
        {
            if (control.Controls == null || control.Controls.Count == 0)
                return Enumerable.Empty<Panel>();

            return control.Controls
                .Cast<Control>()
                .Where(c => typeof(Panel).IsAssignableFrom(c.GetType()))
                .Cast<Panel>()
                .Concat(control.Controls.Cast<Control>().SelectMany(x => GetAllPanels(x)));
        }

        /// <summary>
        /// Возвращает все кнопки внутри переданного Control
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        protected IEnumerable<Button> GetAllButtons(Control control)
        {
            if (control.Controls == null || control.Controls.Count == 0)
                return Enumerable.Empty<Button>();

            return control.Controls.OfType<Button>().Concat(control.Controls.Cast<Control>().SelectMany(x => GetAllButtons(x)));
        }

        /// <summary>
        /// Вызывает AddInputControl_ArrowKeyPressEventListener для всех панелей окна
        /// </summary>
        protected void AddInputControl_ArrowKeyPressEventListener()
        {
            foreach (Panel panel in GetAllPanels(this))
            {
                AddInputControl_ArrowKeyPressEventListener(panel);
            }
        }

        /// <summary>
        /// Для всех полей для ввода внутри переданной панели добавляет слушатель нажатия на стрелки-клавиши "Вверх"/"Вниз"
        /// </summary>
        /// <param name="panel"></param>
        protected void AddInputControl_ArrowKeyPressEventListener(Panel panel)
        {
            foreach (Control inputControl in GetPanelInputControls(panel))
            {
                inputControl.KeyDown += new KeyEventHandler(ArrowKeyPress);
            }
        }

        /// <summary>
        /// Позволяет перемещать фокус между инпутами при помощи стрелок
        /// <вверх>, <вниз> на кливиатуре
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ArrowKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
                return;

            Control prev = null;
            bool activeNext = false;

            foreach (Panel p in GetAllPanels(this))
            {
                foreach (Control c in GetPanelInputControls(p))
                {
                    if (c == (Control)sender)
                    {
                        if (e.KeyCode == Keys.Up && prev != null)
                        {
                            ControlFocus(prev);

                            return;
                        }
                        else if (e.KeyCode == Keys.Down)
                        {
                            activeNext = true;
                            continue;
                        }
                    }

                    if (activeNext)
                    {
                        ControlFocus(c);
                        return;
                    }

                    prev = c;
                }
            }
        }

        private void ControlFocus(Control control)
        {
            control.Focus();

            if (typeof(TextBoxBase).IsAssignableFrom(control.GetType()))
            {
                ((TextBoxBase)control).SelectionStart = 0;
                ((TextBoxBase)control).SelectionLength = 0;
            }
        }

        /// <summary>
        /// Добавляет форме прослушиватель нажатия кнопки Enter
        /// Для корректной работы у передаваемой формы параметр KeyPreview должен быть true
        /// </summary>
        /// <param name="f"></param>
        protected void AddFormEnterPressEvent(Form f)
        {
            f.KeyDown += new KeyEventHandler(EnterKeyPress);
        }

        /// <summary>
        /// При нажатии на Enter вызывает событие клика по кнопке, помеченной тэгом MainButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EnterKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            foreach (Button b in GetAllButtons((Control)sender))
            {
                if (b.Tag != null && b.Tag.ToString() == MainButtonTag)
                {
                    b.PerformClick();
                    break;
                }
            }
        }

        /// <summary>
        /// Проверяет, является ли переданный Control "пустым", т.е. если это TextBox, то
        /// смотрим, пустое ли это текстовое поле, если это SelectBox, то проверяем, содержит ли
        /// он что-либо, если это обычный ListBox, то проверяет, выбраны ли в нем какие-то элементы
        /// </summary>
        /// <param name="field">Проверяемый Control</param>
        /// <returns>true если Control пустойб иначе else</returns>
        protected bool FieldIsEmpty(Control field)
        {
            if (typeof(TextBoxBase).IsAssignableFrom(field.GetType()))
            {
                return ((TextBoxBase)field).Text == "";
            }
            else if (field is ListBox)
            {
                if (((ListBox)field).Name != null && ((ListBox)field).Name.StartsWith("selectedBox"))
                {
                    return ((ListBox)field).Items.Count == 0;
                } else
                {
                    return ((ListBox)field).SelectedItems.Count == 0;
                }
            }

            return true;
        }

        /// <summary>
        /// Очищает переданное поле(TextBox/ListBox)
        /// </summary>
        /// <param name="field"></param>
        protected void ClearField(Control field)
        {
            if (typeof(TextBoxBase).IsAssignableFrom(field.GetType()))
            {
                ((TextBoxBase)field).Clear();
            }
            else if (field is ListBox)
            {
                ((ListBox)field).Items.Clear();
            }
        }
    }
}
