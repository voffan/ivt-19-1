using Autoreport.Database;
using Autoreport.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace TestClientandFilmService
{
    [TestClass]
    public class UnitTestClient
    {
        private static string Phone_number1;
        private static string Phone_number2;
        private static string First_name;
        private static string Middle_name;
        private static string Last_name;
        private static Client test_client;

        private static string film_name;
        private static int year_film;
        private static Film test_film;
        private static Person director;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            Phone_number1 = "89248723514";
            Phone_number2 = "89248751780";
            First_name = "Васильев1";
            Middle_name = "Вася1";
            Last_name = "Васильевич1";

            film_name = "test_name_film";
            year_film = 2000;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            using (DataContext db = Connection.Connect())
            {
                var search1 = db.Films
                    .Where(b => b.Name == "test_name_film"
                           && b.Year == 2000).FirstOrDefault();
                if (search1 != null)
                {
                    Connection.filmService.Delete(search1.Id);
                }

                var search2 = db.Clients
                     .Where(b => b.Last_name == "Васильевич1"
                            && b.First_name == "Васильев1"
                            && b.Middle_name == "Вася1"
                            && b.Phone_number1 == "89248723514"
                            && b.Phone_number2 == "89248751780")
                     .FirstOrDefault();     
                if (search2 != null)
                {
                    Connection.clientService.Delete(search2.Id);
                }
            }
        }

        [TestMethod]
        public void TestFilmAdd()
        {
            Film test_film = new Film();
            Connection.filmService.Add(film_name, year_film, Connection.filmService.GetCountries().First(), Connection.filmService.GetFilmsDirectors().Take(1).ToList(), Connection.filmService.GetGenres().Take(1).ToList());
            using (DataContext db = Connection.Connect())
            {
                var search = db.Films
                     .Where(b => b.Name == "test_name_film"
                            && b.Year == 2000).FirstOrDefault();                       

                Assert.IsNotNull(search);
                if (search != null)
                {
                    Connection.filmService.Delete(search.Id);
                }
            }
        }

        [TestMethod]
        public void TestClientAdd()
        {
            Client test_client = new Client();
            Connection.clientService.Add(Last_name, First_name, Middle_name, Phone_number1, Phone_number2);
            using (DataContext db = Connection.Connect())
            {
                var search = db.Clients
                     .Where(b => b.Last_name == "Васильевич1"
                            && b.First_name == "Васильев1"
                            && b.Middle_name == "Вася1"
                            && b.Phone_number1 == "89248723514"
                            && b.Phone_number2 == "89248751780")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null)
                {
                   // Connection.clientService.Delete(search.Id);
                }
            }
        }
        [TestMethod]
        public void TestFilmDelete()
        {
            Film test_film = new Film();
            Connection.filmService.Add(film_name, year_film, Connection.filmService.GetCountries().First(), Connection.filmService.GetFilmsDirectors().Take(1).ToList(), Connection.filmService.GetGenres().Take(1).ToList());

            using (DataContext db = Connection.Connect())
            {
                var search = db.Films
                     .Where(b => b.Name == "test_name_film"
                            && b.Year == 2000).FirstOrDefault();

                Assert.IsNotNull(search);
                if (search != null)
                {
                    Connection.filmService.Delete(search.Id);
                }

                search = db.Films
                     .Where(b => b.Name == "test_name_film"
                            && b.Year == 2000)
                     .FirstOrDefault();
                Assert.IsNull(search);
            }
        }

        [TestMethod]
        public void TestClientDelete()
        {
            Client test_client = new Client();
            Connection.clientService.Add(Last_name, First_name, Middle_name, Phone_number1, Phone_number2);
            using (DataContext db = Connection.Connect())
            {
                var search = db.Clients
                     .Where(b => b.Last_name == "Васильевич1"
                            && b.First_name == "Васильев1"
                            && b.Middle_name == "Вася1"
                            && b.Phone_number1 == "89248723514"
                            && b.Phone_number2 == "89248751780")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null)
                {
                    Connection.clientService.Delete(search.Id);
                }

                search = db.Clients
                     .Where(b => b.Last_name == "Васильевич1"
                            && b.First_name == "Васильев1"
                            && b.Middle_name == "Вася1"
                            && b.Phone_number1 == "89248723514"
                            && b.Phone_number2 == "89248751780")
                     .FirstOrDefault();
                Assert.IsNull(search);//
            }
        }

        [TestMethod]
        public void TestFilmEdit()
        {
            Film test_film = new Film();
            Connection.filmService.Add(film_name, year_film, Connection.filmService.GetCountries().First(), Connection.filmService.GetFilmsDirectors().Take(1).ToList(), Connection.filmService.GetGenres().Take(1).ToList());
            using (DataContext db = Connection.Connect())
            {
                var f = db.Films
                     .Where(b => b.Name == "test_name_film"
                            && b.Year == 2000).FirstOrDefault();
                test_film = f;
            }
            Connection.filmService.Edit(test_film, "Edit", 2000, 1 , Connection.filmService.GetFilmsDirectors().Take(1).ToList(), Connection.filmService.GetGenres().Take(1).ToList());
            using (DataContext db = Connection.Connect())
            {
                var search = db.Films
                     .Where(b => b.Name == "Edit"
                            && b.Year == 2000).FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null)
                {
                    Connection.filmService.Delete(search.Id);
                }
            }
        }
        [TestMethod]
        public void TestClietnEdit()
        {
            Client test_client = new Client();
            Connection.clientService.Add(Last_name, First_name, Middle_name, Phone_number1, Phone_number2);
            using (DataContext db = Connection.Connect())
            {
                var cl = db.Clients
                     .Where(b => b.Last_name == "Васильевич1"
                            && b.First_name == "Васильев1"
                            && b.Middle_name == "Вася1"
                            && b.Phone_number1 == "89248723514"
                            && b.Phone_number2 == "89248751780")
                     .FirstOrDefault();//
                test_client = cl;
            }
            Connection.clientService.Edit(test_client,Last_name, "Edit", Middle_name, Phone_number1, Phone_number2, 0);
            using (DataContext db = Connection.Connect())
            {
                var search = db.Clients
                     .Where(b => b.Last_name == "Васильевич1"
                            && b.First_name == "Edit"
                            && b.Middle_name == "Вася1"
                            && b.Phone_number1 == "89248723514"
                            && b.Phone_number2 == "89248751780")
                     .FirstOrDefault();//
                Assert.IsNotNull(search);
                if (search != null)
                {
                    Connection.clientService.Delete(search.Id);
                }
            }
        }



    }
}
