using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp_park_app.UI {
    public partial class Form_reports : Form {
        public Form_reports() {
            InitializeComponent();
        }

        Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
        DateTime nowTime = new DateTime();
                
        private void button_reportsRepaired_Click(object sender, EventArgs e) {
            Report(Status.InRepair, "Компьютеры на ремонте", "Периферийная техника на ремонте");
        }

        private void button_reportsWorking_Click(object sender, EventArgs e) {
            Report(Status.Working, "Работающие компьютеры", "Работающая периферийная техника");
        }

        private void button_reportsRemoved_Click(object sender, EventArgs e) {
            Report(Status.Removed, "Списанные компьютеры", "Списанная периферийная техника");
        }

        private void Report(Status status, string comp, string periph) {
            DialogResult res = MessageBox.Show("Экспорт завершен. При нажатии Yes будет предложено сохранить файл, при нажатии No " +
                "будет предложена отмена сохранения.", "Экспорт в Excel", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes) {
                nowTime = DateTime.Now;
                int countRepair = 0;
                
                Workbook wb = Excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet worksheet1 = wb.Sheets[1];
                worksheet1.Activate();
                worksheet1.Cells[1, 3] = comp;
                worksheet1.Cells[2, 1] = "Инвентарный номер";
                worksheet1.Cells[2, 2] = "Отдел";
                worksheet1.Cells[2, 3] = "Сотрудник";
                worksheet1.Cells[2, 4] = "Причина";

                Worksheet worksheet2 = wb.Worksheets.Add();
                worksheet2.Activate();
                worksheet2.Cells[1, 3] = periph;
                worksheet2.Cells[2, 1] = "Инвентарный номер";
                worksheet2.Cells[2, 2] = "Название";
                worksheet2.Cells[2, 3] = "Отдел";
                worksheet2.Cells[2, 4] = "Сотрудник";
                worksheet2.Cells[2, 5] = "Причина";

                using (Context c = new Context()) {
                    //Computers
                    foreach (var i in c.Computers.Include(x => x.Department).Include(z => z.Employee)) {
                        if (i.Status == status && nowTime.Month == i.Date.Month) {
                            worksheet1.Cells[countRepair + 3, 1] = i.ItemNo;
                            worksheet1.Cells[countRepair + 3, 2] = i.Department;
                            worksheet1.Cells[countRepair + 3, 3] = i.Employee;
                            worksheet1.Cells[countRepair + 3, 4] = i.Reason;
                            countRepair++;
                        }
                    }

                    countRepair = 0; 
                    //Peripheral
                    foreach (var i in c.Peripherals.Include(x => x.Employee).Include(y => y.Department)) {
                        if (i.Status == status && nowTime.Month == i.Date.Month) {
                            worksheet2.Cells[countRepair + 3, 1] = i.ItemNo;
                            worksheet2.Cells[countRepair + 3, 2] = i.Name;
                            worksheet2.Cells[countRepair + 3, 3] = i.Department;
                            worksheet2.Cells[countRepair + 3, 4] = i.Employee;
                            worksheet2.Cells[countRepair + 3, 5] = i.Reason;
                            countRepair++;
                        }

                    }
                }

                string fileName = String.Empty;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    fileName = saveFileDialog1.FileName;
                } else {
                    return;
                }

                //сохраняем Workbook
                wb.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                wb.Close();
                Excel.Quit();
                saveFileDialog1.Dispose();
                MessageBox.Show("Файл создан");
            }
            if (res == DialogResult.No) {

            }
        }

        private void button_exit_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
