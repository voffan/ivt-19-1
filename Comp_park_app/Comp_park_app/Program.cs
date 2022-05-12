using Comp_park_app.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp_park_app_form
{
    static class Program
    {
        public static ApplicationContext Context { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Authorization());
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Context = new ApplicationContext(new Form1());
            Context = new ApplicationContext(new Authorization());
            Application.Run(Context);

        }
    }
}
