using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using gallerys.Context;
namespace gallerys.components
{
    public class report
    {
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public report()
        {
            wb = excel.Workbooks.Add(System.Reflection.Missing.Value);
            ws = (Worksheet)wb.Worksheets[1];
        }
        public string openfile()
        {
            string path = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                path = sfd.FileName;
            }
            else
            {
                path = "Невозможно открыть файл";
            }
            return path;
        }
        public void restoration(string s)
        {
            
            if (s == "Невозможно открыть файл")
            {
                MessageBox.Show(s);
            }
            else
            {
                ws.Activate();
                int count = 0;
                using (gallContext c = new gallContext())
                {
                    ws.Cells[1, 2] = "Картины на реставрации";
                    foreach (var i in c.Paintings)
                    {
                        if(i.Status == Models.status.InRestoration)
                        {
                            ws.Cells[count+2,1] = count+1;
                            ws.Cells[count+2,2] = i.Name;
                            count++;
                        }
                    }
                }
            }
        }
        public void exhibrep(string s)
        {

            if (s == "Невозможно открыть файл")
            {
                MessageBox.Show(s);
            }
            else
            {
                ws.Activate();
                int count = 0;
                using (gallContext c = new gallContext())
                {
                    ws.Cells[1, 2] = "Картины в экспозициях";
                    foreach (var i in c.Paintings)
                    {
                        if (i.Status == Models.status.InExhibition)
                        {
                            ws.Cells[count + 2, 1] = count + 1;
                            ws.Cells[count + 2, 2] = i.Name;
                            count++;
                        }
                    }
                }
            }
        }
        public void clos(string path)
        {
            wb.SaveAs(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            wb.Close();
            excel.Quit();
        }
    }
}
