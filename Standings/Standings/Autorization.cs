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
        MainMenu mainmenu = new MainMenu();
        public Autorization()
        {
            InitializeComponent();
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            string Pass = Pass1.Text, Login = Login1.Text;


            try
            {
                Connection.judgeFunctions.Login(Login, Pass);
                this.Hide();
                mainmenu.Show();
          
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Autorization_Load(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration regis = new Registration();
            regis.Show();
        }
    }
}
