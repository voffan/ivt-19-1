using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gallerys;
using gallerys.Context;
using Microsoft.EntityFrameworkCore;
namespace gallerys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gallContext c = new gallContext();
            dataGridView1.DataSource = c.Paintings.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
