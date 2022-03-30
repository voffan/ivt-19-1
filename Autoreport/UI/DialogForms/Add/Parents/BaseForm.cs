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
        /// Возвращает все панели
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

        protected IEnumerable<Button> GetAllButtons(Control control)
        {
            if (control.Controls == null || control.Controls.Count == 0)
                return Enumerable.Empty<Button>();

            return control.Controls.OfType<Button>().Concat(control.Controls.Cast<Control>().SelectMany(x => GetAllButtons(x)));
        }

        protected void AddInputControl_ArrowKeyPressEventListener()
        {
            foreach (Panel panel in GetAllPanels(this))
            {
                AddInputControl_ArrowKeyPressEventListener(panel);
            }
        }

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
                            prev.Focus();
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
                        c.Focus();
                        return;
                    }

                    prev = c;
                }
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
    }
}
