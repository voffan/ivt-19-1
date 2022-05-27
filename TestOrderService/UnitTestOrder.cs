using Autoreport.Database;
using Autoreport.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TestOrderService
{
    [TestClass]
    public class UnitTestOrder
    {
        private static Employee currentEmployee;
        private static Client currentClient;
        private static List<Film> currentFilms;
        private static List<Disk> currentDisks;
        private static Deposit currentDeposit;
        private static Order currentOrder;

        [TestInitialize]
        public void TestInit()
        {
            if (currentEmployee == null)
            {
                Connection.employeeService.Login("admin", "admin");
                currentEmployee = Connection.employeeService.CurrentEmployee;
            }

            currentClient = Connection.clientService.Add("testClient", "testClient", 
                "", "89111111111", "");

            Film f = Connection.filmService.Add("testFilm", 2000,
                Connection.filmService.GetCountries().First(),
                Connection.filmService.GetFilmsDirectors().Take(1).ToList(),
                Connection.filmService.GetGenres().Take(1).ToList());
            currentFilms = new List<Film> { f };

            Disk d = Connection.diskService.Add("testArticle", "10", "150", currentFilms);
            currentDisks = new List<Disk> { d };

            currentDeposit = Connection.depositService.Add("", 150, DepositType.Money, currentClient);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Connection.depositService.Delete(currentDeposit.Id);
            Connection.clientService.Delete(currentClient.Id);
            Connection.filmService.Delete(currentFilms[0].Id);
            Connection.diskService.Delete(currentDisks[0].Id);

            if (currentOrder != null)
                Connection.orderService.Delete(currentOrder.Id);
        }

        [TestMethod]
        public void TestAddOrder()
        {
            currentOrder = Connection.orderService.Add(DateTime.Now, DateTime.Now.AddDays(1),
                currentEmployee, currentDeposit, currentDisks);

            Assert.IsNotNull(currentOrder);
        }

        [TestMethod]
        public void TestGetOrder()
        {
            currentOrder = Connection.orderService.Add(DateTime.Now, DateTime.Now.AddDays(1),
                currentEmployee, currentDeposit, currentDisks);

            Assert.IsNotNull(Connection.orderService.Get(currentOrder.Id));
        }

        [TestMethod]
        public void TestGetExpired()
        {
            currentOrder = Connection.orderService.Add(DateTime.Now, DateTime.Now.AddMilliseconds(100),
                currentEmployee, currentDeposit, currentDisks);

            Thread.Sleep(200);

            Assert.IsNotNull(Connection.orderService
                .GetExpired()
                .FirstOrDefault(x => x.Id == currentOrder.Id));
        }

        [TestMethod]
        public void TestEdit()
        {
            currentOrder = Connection.orderService.Add(DateTime.Now, DateTime.Now.AddDays(1),
                currentEmployee, currentDeposit, currentDisks);

            Connection.orderService.Edit(currentOrder, OrderStatus.Completed, currentOrder.Return_date,
                currentOrder.OrderDeposit, currentOrder.Disks);

            currentOrder = Connection.orderService.Get(currentOrder.Id);

            Assert.AreEqual(OrderStatus.Completed, currentOrder.Status);
        }
    }
}
