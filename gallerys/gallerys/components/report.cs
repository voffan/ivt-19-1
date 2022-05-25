using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
namespace gallerys.components
{
    public class report
    {
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public report(string path)
        {
            wb = excel.Workbooks.Add();
            wb.SaveAs(path);
            //wb = excel.Workbooks.Open(path);
            //ws = (Worksheet)wb.Worksheets[1];
        }
        public void rep(string s)
        {
            if (s == "Невозможно открыть файл")
            {
                MessageBox.Show(s);
            }
            else
            {
                ws.Cells[0, 0] = s;
            }
        }
        public void clos(string path)
        {
            wb.SaveAs(path);
            wb.Close();
            excel.Quit();
        }
    }
}
