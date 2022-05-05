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

namespace Autoreport.UI.Classes
{
    class ReportGenerator
    {
        public void CreateReport()
        {
            XWPFDocument doc = new XWPFDocument();
            Stream sw;
            XWPFParagraph p;

            PutData(doc, GetTodaysOrdersAsText().ToArray());
            PutData(doc, GetExpiredAsText().ToArray());

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Документы (*.docx)|*.docx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((sw = saveFileDialog.OpenFile()) != null)
                {
                    doc.Write(sw);
                    sw.Close();
                }
            }

            doc.Close();
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
