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
    public class UnitTest_deleteFunctions {

        [TestMethod]
        public void TestMethodMotherboard1() {
            MotherboardFunctions motherboard = new MotherboardFunctions();
            motherboard.Add("name", "manuf");
            using (Context c = new Context()) {
                var search = c.Motherboards
                     .Where(b => b.Name == "name" && b.Manufacturer == "manuf")
                     .FirstOrDefault();

                if (search != null) {
                    motherboard.Delete(search.Id);
                }

                search = c.Motherboards
                     .Where(b => b.Name == "name" && b.Manufacturer == "manuf")
                     .FirstOrDefault();

                Assert.IsNull(search);
            }

        }

        [TestMethod]
        public void TestMethodHDD1() {
            HDDFunctions hdd = new HDDFunctions();
            hdd.Add("name", "manuf", 1);
            using (Context c = new Context()) {
                var search = c.HDDs
                     .Where(b => b.Name =="name" && b.Manufacturer == "manuf" && b.Capacity == 1)
                     .FirstOrDefault();

                if (search != null) {
                    hdd.Delete(search.Id);
                }

                search = c.HDDs
                     .Where(b => b.Name == "name" && b.Manufacturer == "manuf" && b.Capacity == 1)
                     .FirstOrDefault();

                Assert.IsNull(search);
            }
        }

        [TestMethod]
        public void TestMethodDepartment1() {
            DepartmentFunctions department = new DepartmentFunctions();
            department.Add("name", 10);
            using (Context c = new Context()) {
                var search = c.Departments
                     .Where(b => b.Name == "name" && b.Number == 10) 
                     .FirstOrDefault();

                if (search != null) {
                    department.Delete(search.Id);
                }

                search = c.Departments
                     .Where(b => b.Name == "name" && b.Number == 10)
                     .FirstOrDefault();

                Assert.IsNull(search);  
            }
        }

        [TestMethod]
        public void TestMethodEmployee1() {
            EmployeeFunctions employee = new EmployeeFunctions();
            employee.Add("name", 1, 2, "");
            using (Context c = new Context()) {
                var search = c.Employees
                     .Where(b => b.Name == "name")
                     .FirstOrDefault();

                if (search != null) {
                    employee.Delete(search.Id);
                }

                search = c.Employees
                     .Where(b => b.Name == "name")
                     .FirstOrDefault();

                Assert.IsNull(search);
            }
        }

        [TestMethod]
        public void TestMethodPosition1() {
            PositionFunctions position = new PositionFunctions();
            position.Add("Admin");
            using (Context c = new Context()) {
                var search = c.Positions
                     .Where(b => b.Name == "Admin")
                     .FirstOrDefault();
                if (search != null) {
                    position.Delete(search.Id);
                }

                search = c.Positions
                     .Where(b => b.Name == "Admin")
                     .FirstOrDefault();

                Assert.IsNull(search);  
            }
        }

        [TestMethod]
        public void TestMethodProcessor1() {
            ProcessorFunctions processor = new ProcessorFunctions();
            processor.Add("Процессор21", "Производитель45", "Частота6752");
            using (Context c = new Context()) {
                var search = c.Processors
                     .Where(b => b.Name == "Процессор21" && b.Manufacturer == "Производитель45" && b.Frequency == "Частота6752")
                     .FirstOrDefault();

                if (search != null) {
                    processor.Delete(search.Id);
                }

                search = c.Processors
                     .Where(b => b.Name == "Процессор21" && b.Manufacturer == "Производитель45" && b.Frequency == "Частота6752")
                     .FirstOrDefault();

                Assert.IsNull(search);
            }
        }

        [TestMethod]
        public void TestMethodRAM1() {
            RAMFunctions ram = new RAMFunctions();
            ram.Add("Оперативная память 6753", "Производитель6731", 234);
            using (Context c = new Context()) {
                var search = c.RAMs
                     .Where(b => b.Name == "Оперативная память 6753" && b.Manufacturer == "Производитель6731" && b.Capacity == 234)
                     .FirstOrDefault();

                if (search != null) {
                    ram.Delete(search.Id);
                }

                search = c.RAMs
                     .Where(b => b.Name == "Оперативная память 6753" && b.Manufacturer == "Производитель6731" && b.Capacity == 234)
                     .FirstOrDefault();

                Assert.IsNull(search); 
            }
        }

        [TestMethod]
        public void TestMethodPeripheral1() {
            DateTime date = new DateTime(2022, 5, 6);
            PeripheralFunctions peripheral = new PeripheralFunctions();
            peripheral.Add("Принтер46", "Е87", Status.Working, 1, 9, date, "");
            using (Context c = new Context()) {
                var search = c.Peripherals
                     .Where(b => b.Name == "Принтер46" && b.ItemNo == "Е87" && b.Status == Status.Working && b.DepartmentId == 1 && b.EmployeeId == 5 && new DateTime(2022, 5, 6) == b.Date)
                     .FirstOrDefault();

                if (search != null) {
                    peripheral.Delete(search.Id);
                }

                search = c.Peripherals
                     .Where(b => b.Name == "Принтер46" && b.ItemNo == "Е87" && b.Status == Status.Working && b.DepartmentId == 1 && b.EmployeeId == 5 && new DateTime(2022, 5, 6) == b.Date)
                     .FirstOrDefault();

                Assert.IsNull(search);
            }
        }
    }
}
