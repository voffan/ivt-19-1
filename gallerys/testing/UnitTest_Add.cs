using gallerys;
using gallerys.components;
using gallerys.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace testing
{
    [TestClass]
    public class UnitTest_Add
    {
        [TestMethod]
        public void TestMethod_AuthorAdds()
        {
            AutorSer aus = new AutorSer();
            aus.Add("name", "bio");
            using (gallContext c = new gallContext())
            {
                var search = c.Authors
                     .Where(b => b.Name == "name" && b.Bio == "bio")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null)
                {
                    aus.Remove(search.Id);
                }
            }
        }
        [TestMethod]
        public void TestMethod_PaintAdds()
        {
            PaintSer ps = new PaintSer();
            ps.Add("name", 2001, 1000, gallerys.Models.status.InExhibition, 1, 1);
            using (gallContext c = new gallContext())
            {
                var search = c.Paintings
                     .Where(b => b.Name == "name" && b.Year == 2001 && b.Price == 1000 && b.Status == gallerys.Models.status.InExhibition && b.AuthorId == 1 && b.GenreId == 1)
                     .FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null)
                {
                    ps.Remove(search.Id);
                }
            }
        }
        [TestMethod]
        public void TestMethod_EmployeeAdds()
        {
            EmployeeSer ems = new EmployeeSer();
            ems.Add("name", "login", "pass", gallerys.Models.Right.manager);
            using (gallContext c = new gallContext())
            {
                var search = c.Employees
                     .Where(b => b.Name == "name" && b.Login1 == "login" && b.Passw1 == "pass" && b.Right == gallerys.Models.Right.manager)
                     .FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null)
                {
                    ems.Remove(search.Id);
                }
            }
        }
        [TestMethod]
        public void TestMethod_ExhibithionAdds()
        {
            ExhiSer exs = new ExhiSer();
            exs.Add("name", "place");
            using (gallContext c = new gallContext())
            {
                var search = c.Exhibitions
                     .Where(b => b.Name == "name" && b.Place == "place")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null)
                {
                    exs.Remove(search.Id);
                }
            }
        }
        [TestMethod]
        public void TestMethod_GenreAdds()
        {
            JanrSer jas = new JanrSer();
            jas.Add("name");
            using (gallContext c = new gallContext())
            {
                var search = c.Genres
                     .Where(b => b.Name == "name")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null)
                {
                    jas.Remove(search.Id);
                }
            }
        }
        [TestMethod]
        public void TestMethod_JournalAdds()
        {
            JournalSer jos = new JournalSer();
            DateTime date = new DateTime(2022, 6, 5);
            jos.Add(date, 1, 1, 1, 1);
            using (gallContext c = new gallContext())
            {
                var search = c.Journals
                     .Where(b => b.Oper_date == date && b.PaintingId == 1 && b.ToId == 1 && b.FromId == 1 && b.EmployeeId == 1)
                     .FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null)
                {
                    jos.Remove(search.Id);
                }
            }
        }
    }
}
