using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autoreport.Database;
using Microsoft.EntityFrameworkCore;
using Autoreport.UI;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Autoreport
{
    static class Program
    {
        public static IConfigurationRoot configuration;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }


	}
}
