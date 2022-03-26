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
        public BaseForm()
        {
            InitializeComponent();
        }

        protected IEnumerable<Control> GetPanelInputControls(Panel p)
        {
            foreach (Control underC in p.Controls)
            {
                if (underC.GetType() == typeof(Label) || underC.GetType() == typeof(Panel))
                    continue;

                if (typeof(TextBoxBase).IsAssignableFrom(underC.GetType()) ||
                    underC.GetType() == typeof(ListBox)) 
                {
                    yield return underC;
                }
            }
        }

        protected IEnumerable<Panel> GetPanels()
        {
            foreach (Control c in this.Controls)
            {
                if (typeof(Panel).IsAssignableFrom(c.GetType()))
                {
                    yield return (Panel)c;
                }
            }
        }

        protected void AddInputControl_ArrowKeyPressEventListener()
        {
            foreach (Panel panel in GetPanels())
            {
                foreach (Control inputControl in GetPanelInputControls(panel))
                {
                    inputControl.KeyDown += new KeyEventHandler(ArrowKeyPress);
                }
            }
        }

        protected void AddInputControl_ArrowKeyPressEventListener(Panel panel)
        {
            foreach (Control inputControl in GetPanelInputControls(panel))
            {
                inputControl.KeyDown += new KeyEventHandler(ArrowKeyPress);
            }
        }

        protected void ArrowKeyPress(object sender, KeyEventArgs e)
        {
            Control prev = null;
            bool activeNext = false;

            foreach (Panel p in GetPanels())
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
    }
}
