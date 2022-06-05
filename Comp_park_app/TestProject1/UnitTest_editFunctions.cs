using Comp_park_app;
using Comp_park_app.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1 {
    [TestClass]
    public class UnitTest_editFunctions {

        [TestMethod]
        public void TestMethodMotherboard1() {
            MotherboardFunctions motherboard = new MotherboardFunctions();
            motherboard.Edit(1, "Имя_измененно", "manuf");
            using (Context c = new Context()) {
                var search = c.Motherboards
                     .Where(b => b.Name == "Имя_измененно" && b.Manufacturer == "manuf")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }

        [TestMethod]
        public void TestMethodHDD1() {
            HDDFunctions hdd = new HDDFunctions();
            hdd.Edit(1, "name", "manuf", 1);
            using (Context c = new Context()) {
                var search = c.HDDs
                     .Where(b => b.Name =="name" && b.Manufacturer == "manuf" && b.Capacity == 1)
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }

        [TestMethod]
        public void TestMethodDepartment1() {
            DepartmentFunctions department = new DepartmentFunctions();
            department.Edit(1, "name", 1);
            using (Context c = new Context()) {
                var search = c.Departments
                     .Where(b => b.Name == "name" && b.Number == 1) 
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }

        [TestMethod]
        public void TestMethodEmployee1() {
            EmployeeFunctions employee = new EmployeeFunctions();
            employee.Edit(1, "Aman", 1, 1, "");
            using (Context c = new Context()) {
                var search = c.Employees
                     .Where(b => b.Name == "Aman")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }

        [TestMethod]
        public void TestMethodPosition1() {
            PositionFunctions position = new PositionFunctions();
            position.Edit(1, "Admin");
            using (Context c = new Context()) {
                var search = c.Positions
                     .Where(b => b.Name == "Admin")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }

        [TestMethod]
        public void TestMethodProcessor1() {
            ProcessorFunctions processor = new ProcessorFunctions();
            processor.Edit(1, "Процессор21", "Производитель45", "Частота6752");
            using (Context c = new Context()) {
                var search = c.Processors
                     .Where(b => b.Name == "Процессор21" && b.Manufacturer == "Производитель45" && b.Frequency == "Частота6752")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }

        [TestMethod]
        public void TestMethodRAM1() {
            RAMFunctions ram = new RAMFunctions();
            ram.Edit(1, "Оперативная память 6753", "Производитель6731", 234);
            using (Context c = new Context()) {
                var search = c.RAMs
                     .Where(b => b.Name == "Оперативная память 6753" && b.Manufacturer == "Производитель6731" && b.Capacity == 234)
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }

        [TestMethod]
        public void TestMethodPeripheral1() {
            DateTime date = new DateTime(2022, 5, 6);
            PeripheralFunctions peripheral = new PeripheralFunctions();
            peripheral.Edit(1, "Принтер46", "Е87", Status.Working, 1, 5, date, "");
            using (Context c = new Context()) {
                var search = c.Peripherals
                     .Where(b => b.Name == "Принтер46" && b.ItemNo == "Е87" && b.Status == Status.Working && b.DepartmentId == 1 && b.EmployeeId == 5 && new DateTime(2022, 5, 6) == b.Date)
                     .FirstOrDefault();
                Assert.IsNotNull(search);
            }
        }
    }
}
