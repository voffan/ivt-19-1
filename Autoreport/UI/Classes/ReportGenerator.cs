using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autoreport.Services;
using Autoreport.Models;
using Autoreport.Database;
using NPOI;
using NPOI.XWPF.UserModel;
using System.IO;
using System.Windows.Forms;
using NPOI.OpenXmlFormats.Wordprocessing;

namespace Autoreport.UI.Classes
{
    class ReportGenerator
    {
        internal void CreateTodayOrdersReport()
        {
            Stream sw;

            XWPFDocument docTodaysOrders = new XWPFDocument();
            PutHeader(docTodaysOrders, "Совершенные за день заказы");
            PutData(docTodaysOrders, GetTodaysOrdersAsText().ToArray());

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Документы (*.docx)|*.docx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((sw = saveFileDialog.OpenFile()) != null)
                {
                    docTodaysOrders.Write(sw);
                    sw.Close();
                }
            }

            docTodaysOrders.Close();
        }

        internal void CreateExpiredOrdersReport()
        {
            Stream sw;

            XWPFDocument docExpiredOrders = new XWPFDocument();
            PutHeader(docExpiredOrders, "Клиенты, не вернувшие диски вовремя");
            PutData(docExpiredOrders, GetExpiredAsText().ToArray());

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Документы (*.docx)|*.docx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((sw = saveFileDialog.OpenFile()) != null)
                {
                    docExpiredOrders.Write(sw);
                    sw.Close();
                }
            }

            docExpiredOrders.Close();
        }

        public void PutHeader(XWPFDocument document, string theme)
        {
            XWPFParagraph paragraph = document.CreateParagraph();
            paragraph.Alignment = ParagraphAlignment.CENTER;

            XWPFRun r = paragraph.CreateRun();
            string text = $"Отчет: {theme} от {DateTime.Now.ToString("dd.MM.yyyy")}";

            r.SetText(text);
            r.IsBold = true;
            r.FontSize = 16;

            paragraph = document.CreateParagraph();
            paragraph.Alignment = ParagraphAlignment.RIGHT;

            r = paragraph.CreateRun();
            r.SetText($"Сотрудник: {Connection.employeeService.CurrentEmployee}");
            r.IsItalic = true;
        }

        public void PutData(XWPFDocument document, string[] data)
        {
            XWPFRun r;
            XWPFParagraph paragraph;

            foreach (string line in data)
            {
                paragraph = document.CreateParagraph();
                r = paragraph.CreateRun();
                r.SetText(line);
            }
        }

        public IEnumerable<string> GetTodaysOrdersAsText()
        {
            DateTime today = DateTime.Now;
            List<Order> todayOrders = Connection.orderService.Get(today);

            foreach (Order order in todayOrders)
            {
                string orderEmployee = order.OrderEmployee.ToString();
                string orderClient = order.OrderClient.ToString();
                string orderDisks = String.Join(", ", order.Disks.Select(x => x.Article));
                double orderCost = order.Disks.Sum(x => x.Cost);

                yield return $"{orderEmployee} одобрил {orderClient} заказ на диски: {orderDisks}. Сумма заказа {orderCost}. Залог: {order.OrderDeposit.ToString()}";
            }
        }

        public IEnumerable<string> GetExpiredAsText()
        {
            List<Order> expiredOrders = Connection.orderService.GetExpired();

            foreach (Order order in expiredOrders)
            {
                string orderClient = order.OrderClient.ToString();
                string orderDisks = String.Join(", ", order.Disks.Select(x => x.Article));
                string orderDate = order.Return_date.ToString("dd/MM/yyyy");

                yield return $"{orderClient} не вернул к {orderDate} диски: {orderDisks}";
            }
        }
    }
}
