﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gallerys.Forms.FormsforAdd
{
    public partial class AddPlace : Form
    {
        public AddPlace(string s, string s1)
        {
            InitializeComponent();
            this.Text = s + " " + s1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
