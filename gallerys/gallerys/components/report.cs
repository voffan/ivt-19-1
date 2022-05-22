//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Office.Interop.Excel;
//using _Excel = Microsoft.Office.Interop.Excel;
//using System.Windows.Forms;
//using Microsoft.EntityFrameworkCore;
//namespace gallerys.components
//{
//    public class report
//    {
//        _Application excel = new _Excel.Application();
//        Workbook wb;
//        Worksheet ws;
//        public report(string path, int sheet)
//        {
//            wb = excel.Workbooks.Open(path);
//            ws = wb.Sheets[1];
//        }
//        public string openfile()
//        {
//            SaveFileDialog sfd = new SaveFileDialog();
//            sfd.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
//            sfd.OverwritePrompt = true;
//            sfd.CheckPathExists = true;
//            if(sfd.ShowDialog() == DialogResult.OK)
//            {
//                return sfd.FileName;
//            }
//            else
//            {
//                return "Невозможно открыть файл";
//            }
//        }
//        public void rep(string s)
//        {
//            if (s == "Невозможно открыть файл")
//            {
//                MessageBox.Show(s);
//            }
//            else
//            {
                
//            }
//        }
//    }
//}
