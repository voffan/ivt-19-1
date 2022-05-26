using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comp_park_app.Functions;
using Comp_park_app;
using System.Linq;
using System;

namespace TestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethodMotherboard1() {
            MotherboardFunctions motherboard = new MotherboardFunctions();
            motherboard.Add("name", "manuf");
            using (Context c = new Context()) {
                var search = c.Motherboards
                     .Where(b => b.Name == "name" && b.Manufacturer == "manuf")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null) {
                    motherboard.Delete(search.Id);
                }
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
                Assert.IsNotNull(search);
                if (search != null) {
                    hdd.Delete(search.Id);
                }
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
                Assert.IsNotNull(search);
                if (search != null) {
                    department.Delete(search.Id);
                }
            }
        }

        [TestMethod]
        public void TestMethodEmployee1() {
            EmployeeFunctions employee = new EmployeeFunctions();
            employee.Add("name", 1, 1, "");
            using (Context c = new Context()) {
                var search = c.Employees
                     .Where(b => b.Name == "name")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null) {
                    employee.Delete(search.Id);
                }
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
                Assert.IsNotNull(search);
                if (search != null) {
                    position.Delete(search.Id);
                }
            }
        }

        [TestMethod]
        public void TestMethodProcessor1() {
            ProcessorFunctions processor = new ProcessorFunctions();
            processor.Add("���������21", "�������������45", "�������6752");
            using (Context c = new Context()) {
                var search = c.Processors
                     .Where(b => b.Name == "���������21" && b.Manufacturer == "�������������45" && b.Frequency == "�������6752")
                     .FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null) {
                    processor.Delete(search.Id);
                }
            }
        }

        [TestMethod]
        public void TestMethodRAM1() {
            RAMFunctions ram = new RAMFunctions();
            ram.Add("����������� ������ 6753", "�������������6731", 234);
            using (Context c = new Context()) {
                var search = c.RAMs
                     .Where(b => b.Name == "����������� ������ 6753" && b.Manufacturer == "�������������6731" && b.Capacity == 234)
                     .FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null) {
                    ram.Delete(search.Id);
                }
            }
        }

        [TestMethod]
        public void TestMethodPeripheral1() {
            DateTime date = new DateTime(2022, 5, 6);
            PeripheralFunctions peripheral = new PeripheralFunctions();
            peripheral.Add("�������46", "�87", Status.Working, 1, 5, date, "");
            using (Context c = new Context()) {
                var search = c.Peripherals
                     .Where(b => b.Name == "�������46" && b.ItemNo == "�87" && b.Status == Status.Working && b.DepartmentId == 1 && b.EmployeeId == 5 && new DateTime(2022, 5, 6) == b.Date)
                     .FirstOrDefault();
                Assert.IsNotNull(search);
                if (search != null) {
                    peripheral.Delete(search.Id);
                }
            }
        }
    }
}