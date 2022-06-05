using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gallerys;
using gallerys.components;
using gallerys.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testing
{
    [TestClass]
    public class UnitTest_Edit
    {
        [TestMethod]
        public void TestMethod_AuthorEdit()
        {
            AutorSer aus = new AutorSer();
            aus.Edit(23, "Имя_измененно", "bio_edit");
            using (gallContext c = new gallContext())
            {
                var search = c.Authors
                     .Where(b => b.Name == "Имя_измененно" && b.Bio == "bio_edit")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }
        [TestMethod]
        public void TestMethod_PaintEdit()
        {
            PaintSer ps = new PaintSer();
            ps.Edit(16, "name", 2001, 1000, gallerys.Models.status.InExhibition, 1, 1);
            using (gallContext c = new gallContext())
            {
                var search = c.Paintings
                     .Where(b => b.Name == "name" && b.Year == 2001 && b.Price == 1000 && b.Status == gallerys.Models.status.InExhibition && b.AuthorId == 1 && b.GenreId == 1)
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }
        [TestMethod]
        public void TestMethod_EmployeeEdit()
        {
            EmployeeSer ems = new EmployeeSer();
            ems.Edit(11, "name", "login", "pass", gallerys.Models.Right.manager);
            using (gallContext c = new gallContext())
            {
                var search = c.Employees
                     .Where(b => b.Name == "name" && b.Login1 == "login" && b.Passw1 == "pass" && b.Right == gallerys.Models.Right.manager)
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }
        [TestMethod]
        public void TestMethod_ExhibithionEdit()
        {
            ExhiSer exs = new ExhiSer();
            exs.Edit(5, "name", "place");
            using (gallContext c = new gallContext())
            {
                var search = c.Exhibitions
                     .Where(b => b.Name == "name" && b.Place == "place")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }
        [TestMethod]
        public void TestMethod_GenreEdit()
        {
            JanrSer jas = new JanrSer();
            jas.Edit(13, "name1");
            using (gallContext c = new gallContext())
            {
                var search = c.Genres
                     .Where(b => b.Name == "name1")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }
        [TestMethod]
        public void TestMethod_JournalEdit()
        {
            JournalSer jos = new JournalSer();
            DateTime date = new DateTime(2022, 6, 5);
            jos.Edit(4, date, 1, 1, 1, 1);
            using (gallContext c = new gallContext())
            {
                var search = c.Journals
                     .Where(b => b.Oper_date == date && b.PaintingId == 1 && b.ToId == 1 && b.FromId == 1 && b.EmployeeId == 1)
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }
    }
}
