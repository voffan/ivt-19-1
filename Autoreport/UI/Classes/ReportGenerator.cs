using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autoreport.Services;
using Autoreport.Models;
using Autoreport.Database;

namespace Autoreport.UI.Classes
{
    class ReportGenerator
    {
        public void CreateReport()
        {
            DateTime today = DateTime.Now;

            List<Order> todayOrders = Connection.orderService.Get(today);
            List<Order> expiredOrders = Connection.orderService.GetExpired();

            foreach (Order order in todayOrders)
            {
                string orderEmployee = order.OrderEmployee.ToString();
                string orderClient = order.OrderClient.ToString();
                string orderDisks = String.Join(", ", order.Disks.Select(x => x.Article));
                double orderCost = order.Disks.Sum(x => x.Cost);

                Console.WriteLine($"{orderEmployee} одобрил {orderClient} заказ на диски: {orderDisks}. Сумма заказа {orderCost}. Залог: {order.OrderDeposit.ToString()}");
            }

            foreach (Order order in expiredOrders)
            {
                string orderClient = order.OrderClient.ToString();
                string orderDisks = String.Join(", ", order.Disks.Select(x => x.Article));
                string orderDate = order.Return_date.ToString("dd/MM/yyyy");

                Console.WriteLine($"{orderClient} не вернул к {orderDate} диски: {orderDisks}");
            }
        }
    }
}
