using Autoreport.Database;
using Autoreport.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestOrderService
{
    [TestClass]
    public class UnitTestOrder
    {
        int newOrderId;

        [TestMethod]
        public void TestAddOrder()
        {
            Connection.employeeService.Login("admin", "admin");
            Employee empl = Connection.employeeService.CurrentEmployee;

            Connection.clientService.Add("testClient", "testClient", "", "89111111111", "");
            Client client = Connection.clientService.GetAll()
                .FirstOrDefault(x => x.Last_name == "testClient" && 
                    x.First_name == "testClient" && 
                    x.Phone_number1 == "89111111111");

            Connection.filmService.Add("testFilm", 2000,
                Connection.filmService.GetCountries().First(),
                Connection.filmService.GetFilmsDirectors().Take(1).ToList(),
                Connection.filmService.GetGenres().Take(1).ToList());
            Film film = Connection.filmService.GetAll()
                .FirstOrDefault(x => x.Name == "testFilm" && x.Year == 2000);

            Connection.diskService.Add("testArticle", "10", "150", new List<Film> { film });
            Disk disk = Connection.diskService.GetAll()
                .FirstOrDefault(x => x.Article == "testArticle" && x.General_count == 10 && x.Cost == 150);

            Connection.depositService.Add("", 150, DepositType.Money, client);
            Deposit deposit = Connection.depositService.GetAll()
                .FirstOrDefault(x => x.MoneyValue == 150 &&
                    x.DepositType == DepositType.Money &&
                    x.Owner.Id == client.Id);

            using (DataContext db = Connection.Connect())
            {
                newOrderId = Connection.orderService.Add(DateTime.Now, DateTime.Now.AddDays(1),
                    empl, deposit, new List<Disk> { disk });
            }

            Order newOrder = Connection.orderService.GetAll()
                .FirstOrDefault(x => x.Id == newOrderId);

            Assert.IsNotNull(newOrder);
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
