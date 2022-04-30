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
        protected string EnterButtonTag = "EnterButton"; // тэг для таких кнопок как "Сохранить"/"Войти" и т.д.

        public BaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Возвращает текстовые поля, либо листбоксы, хранящиеся внутри передаваемого Control
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected IEnumerable<Control> GetAllPanelDataBoxes(Control p)
        {
            foreach (Control control in GetNestedControls<TextBoxBase>(p).Cast<Control>().Concat(GetNestedControls<ListBox>(p)))
            {
                if (typeof(TextBoxBase).IsAssignableFrom(control.GetType()) || control is ListBox) 
                {
                    yield return control;
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
        /// Возвращает все Controls типа ControlType, 
        /// вложенные в передаваемый Control
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        protected IEnumerable<ControlType> GetNestedControls<ControlType>(Control control)
        {
            if (control.Controls == null || control.Controls.Count == 0)
                return Enumerable.Empty<ControlType>();

            return control.Controls
                .OfType<ControlType>()
                .Concat(control.Controls
                    .Cast<Control>()
                    .SelectMany(x => GetNestedControls<ControlType>(x)));
        }

        /// <summary>
        /// Вызывает AddArrowKeyEventListener для всех панелей окна
        /// </summary>
        protected void AddArrowKeyEventListener()
        {
            foreach (Panel panel in GetAllPanels(this))
            {
                AddArrowKeyEventListener(panel);
            }
        }

        /// <summary>
        /// Для всех полей для ввода внутри панели добавляет слушателя события нажатия
        /// на клавиши-стрелки "Вверх"-"Вниз"
        /// </summary>
        /// <param name="panel"></param>
        protected void AddArrowKeyEventListener(Panel panel)
        {
            foreach (Control inputControl in GetAllPanelDataBoxes(panel))
            {
                inputControl.KeyDown += new KeyEventHandler(ArrowKeyPress);
            }
        }

        /// <summary>
        /// Позволяет перемещать фокус между инпутами при помощи клавиш-стрелок
        /// "Вверх", "Вниз" на кливиатуре
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
                foreach (Control c in GetAllPanelDataBoxes(p))
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

        /// <summary>
        /// Устанавливает фокус на передаваемый виджет.
        /// Для текстовых полей устанавливает также положение курсора на начало поля.
        /// </summary>
        /// <param name="control"></param>
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
        /// Добавляет форме прослушиватель нажатия кнопки, имеющей тэг "EnterButton".
        /// Для корректной работы у передаваемой формы параметр KeyPreview должен быть равен true
        /// </summary>
        /// <param name="f"></param>
        protected void AddEnterKeyEventListener(Form f)
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

            foreach (Button enterBtn in GetNestedControls<Button>((Control)sender))
            {
                if (enterBtn.Tag != null && enterBtn.Tag.ToString() == EnterButtonTag)
                {
                    enterBtn.PerformClick();
                    break;
                }
            }
        }

        /// <summary>
        /// Проверяет, является ли переданный Control "пустым".
        /// Еесли это TextBox, то смотрим, пустое ли это текстовое поле,
        /// если это ListBox с тэгом "selectedBox", то проверяем, содержит ли он что-либо,
        /// если это обычный ListBox, то проверяет, выбраны ли в нем какие-то элементы
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
                if (((ListBox)field).Name != null && ((ListBox)field).Name.StartsWith("SelectedBox"))
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
