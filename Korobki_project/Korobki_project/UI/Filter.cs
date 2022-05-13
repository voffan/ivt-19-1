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
using Korobki_project.UI;
using Microsoft.EntityFrameworkCore;
using Korobki_project.Classes;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using Korobki_project.Functions;
using System.Diagnostics;
using System.IO;

namespace Korobki_project.UI
{
	public partial class Filter : Form
	{
		public Filter()
		{
			InitializeComponent();
		}

		private void Filter_Load(object sender, EventArgs e)
		{
		}

        DateTime Plan_start;
        DateTime Plan_end;
        DateTime Prod_start;
        DateTime Prod_end;

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
		{
            Plan_start = monthCalendar1.SelectionRange.Start;
			Plan_end = monthCalendar1.SelectionRange.End;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            using (Context c = new Context())
            {
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Дата";
                dataGridView1.Columns[1].Name = "Продукт";
                dataGridView1.Columns[2].Name = "Количество";
                foreach (var i in c.Plans.Include(x => x.Product).OrderBy(e => e.PlanDate))
                {
                    DateTime Cur_date = Convert.ToDateTime(i.PlanDate);
                    if (Plan_start <= Cur_date && Cur_date <= Plan_end)
                    {
                        dataGridView1.Rows.Add(i.PlanDate, i.Product, i.Count_box);
                    }
                }

            }
        } // Plan datepicker 

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            Prod_start = monthCalendar2.SelectionRange.Start;
            Prod_end = monthCalendar2.SelectionRange.End;
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            using (Context c = new Context())
            {
                dataGridView2.ColumnCount = 4;
                dataGridView2.Columns[0].Name = "Расписание";
                dataGridView2.Columns[1].Name = "Размер Коробки";
                dataGridView2.Columns[2].Name = "Число";
                dataGridView2.Columns[3].Name = "Комментарий";
                foreach (var i in c.Productions.Include(x => x.Team).Include("Product").OrderBy(e => e.Team.Date))
                {
                    DateTime Cur_date = Convert.ToDateTime(i.Team.Date);
                    if (Prod_start <= Cur_date && Cur_date <= Prod_end)
                    {
                        dataGridView2.Rows.Add(i.Team, i.Product, i.Count, i.Comment);
                    }
                }

            }
        } // Production datepicker 

        private void report(int report_id)
		{
            string path = "/";
            try
            {
                using (Excel.ExcelTools tools = new Excel.ExcelTools())
                {
                    if (tools.Open(filePath: Path.Combine(path)))
                    {
                        using (Context c = new Context())
                        {
                            if (report_id == 1)
                            {
                                int count = 1;
                                tools.Set(column: "A", row: count, data: "Дата плана");
                                tools.Set(column: "B", row: count, data: "Размер коробки");
                                tools.Set(column: "C", row: count, data: "Количество коробок");
                                tools.Set(column: "D", row: count, data: "От " + Plan_start.ToString("dd.MM.yyyy") +
                                    " до " + Plan_end.ToString("dd.MM.yyyy"));
                                count++;
                                foreach (var i in c.Plans.Include(x => x.Product).OrderBy(e => e.PlanDate))
                                {
                                    DateTime Cur_date = Convert.ToDateTime(i.PlanDate);
                                    if (Plan_start <= Cur_date && Cur_date <= Plan_end)
                                    {
                                        tools.Set(column: "A", row: count, data: i.PlanDate);
                                        tools.Set(column: "B", row: count, data: i.Product);
                                        tools.Set(column: "C", row: count, data: i.Count_box);
                                        count++;
                                    }
                                }
                            } // Plan
                            else
                            {
                                int count = 1;

                                tools.Set(column: "A", row: count, data: "Расписание");
                                tools.Set(column: "B", row: count, data: "Размер Коробки");
                                tools.Set(column: "C", row: count, data: "Число");
                                tools.Set(column: "D", row: count, data: "Комментарий");
                                tools.Set(column: "E", row: count, data: "От " + Prod_start.ToString("dd.MM.yyyy") +
                                    " до " + Prod_end.ToString("dd.MM.yyyy"));
                                count++;
                                foreach (var i in c.Productions.Include(x => x.Team).Include("Product").OrderBy(e => e.Team.Date))
                                {
                                    DateTime Cur_date = Convert.ToDateTime(i.Team.Date);
                                    if (Prod_start <= Cur_date && Cur_date <= Prod_end)
                                    {
                                        tools.Set(column: "A", row: count, data: i.Team);
                                        tools.Set(column: "B", row: count, data: i.Product);
                                        tools.Set(column: "C", row: count, data: i.Count);
                                        tools.Set(column: "D", row: count, data: i.Comment);
                                        count++;
                                    }
                                }
                            } // Production
                        }
                        tools.Save(path);
                    }
                    tools.Clear();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            //Process.Start(file);
        }

        private void button1_Click(object sender, EventArgs e)
		{
            report(1);
        } // Plan report

		private void button2_Click(object sender, EventArgs e)
		{
            report(2);
        } // Production report
	}
}
