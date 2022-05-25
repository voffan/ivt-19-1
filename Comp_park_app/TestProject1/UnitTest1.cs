using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comp_park_app.Functions;
using Comp_park_app;
using System.Linq;

namespace TestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethodMotherboard1() {
            MotherboardFunctions motherboard = new MotherboardFunctions();
            motherboard.Add("name", "manuf");
            using (Context c = new Context()) {
                var search = c.Motherboards
                     .Where(b => b.Name.Contains("name"))
                     .Where(a => a.Manufacturer.Contains("manuf"))
                     .FirstOrDefault();
                Assert.AreEqual("name", search.Name);
            } 
        }

        [TestMethod]
        public void TestMethodHDD1() {
            HDDFunctions hdd = new HDDFunctions();
            hdd.Add("name", "manuf", 1);
            using (Context c = new Context()) {
                var search = c.HDDs
                     .Where(b => b.Name.Contains("name"))
                     .Where(a => a.Manufacturer.Contains("manuf"))
                     .Where(q => q.Capacity.Equals(1))
                     .FirstOrDefault();
                Assert.AreEqual("name", search.Name);
            }
        }

        [TestMethod]
        public void TestMethodDepartment1() {
            DepartmentFunctions department = new DepartmentFunctions();
            department.Add("name", 10);
            using (Context c = new Context()) {
                var search = c.Departments
                     .Where(b => b.Name.Contains("name"))
                     .Where(q => q.Number.Equals(10))
                     .FirstOrDefault();
                Assert.AreEqual(10, search.Number);
            }
        }

        [TestMethod]
        public void TestMethodEmployee1() {
            EmployeeFunctions employee = new EmployeeFunctions();
            //employee.Add("name", 10);
            using (Context c = new Context()) {
                var search = c.Employees
                     .Where(b => b.Name.Contains("Аман"))
                     .FirstOrDefault();
                Assert.AreEqual("Аман", search.Name);
            }
        }

    }
}