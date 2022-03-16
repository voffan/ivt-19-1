using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Korobki_project;
using Microsoft.EntityFrameworkCore;


namespace Korobki_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Context c = new Context();
           dataGridView1.DataSource = c.Employees.Join(c.Shifts, e => e.ShiftId, s => s.Id, (e, s) => new
            {
                Id = e.Id,
                Name = e.Name,
                PositionId = e.PositionId,
                Position = e.Position,
                PhoneNumber = e.PhoneNumber,
                Adress = e.Adress,
                Shift = s.Name
            }).Join(c.Positions, e => e.PositionId, p => p.Id, (e, p) => new
            {
                Id = e.Id,
                Name = e.Name,
                Position = p.Name,
                PhoneNumber = e.PhoneNumber,
                Adress = e.Adress,
                Shift = e.Shift
            }).ToList();
            //dataGridView1.DataSource = c.Employees.Include("Position").ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
