using Autoreport.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestOrderService
{
    [TestClass]
    public class UnitTestOrder
    {
        int newOrderId;

        [TestMethod]
        public void TestAddOrder()
        {

        }

        [TestMethod]
        public void TestGetOrder()
        {
            using (DataContext db = Connection.Connect())
            {
                Connection.orderService.GetAll().
            }
        }
    }
}
