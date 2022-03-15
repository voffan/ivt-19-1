using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Standings.Database;

namespace Standings
{
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }
        MainMenu mainmenu = new MainMenu();
        private void button1_Click_1(object sender, EventArgs e)
        {
            string Pass = Pass1.Text, Login = Login1.Text;


            try
            {
                Connection.judgeFunctions.Login(Login, Pass);
                Close();
                
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
