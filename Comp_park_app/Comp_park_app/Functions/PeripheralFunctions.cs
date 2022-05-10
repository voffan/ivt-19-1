﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp_park_app.Functions {
    class PeripheralFunctions {
        public void Add(string name, string itemno, Status status, int departmentid, int employeeid, DateTime date, string reason) {
            Peripheral peripheral = new Peripheral() {
                Name = name,
                ItemNo = itemno,
                Status = status,
                DepartmentId = departmentid,
                EmployeeId = employeeid,
                Date = date,
                Reason = reason
            };

            using (Context c = new Context()) {
                //... initiate field
                c.Peripherals.Add(peripheral);
                c.SaveChanges();
            }
        }

        public void Delete(int index) {
            Peripheral peripheral;
            using (Context c = new Context()) {
                peripheral = c.Peripherals.Find(index);
                c.Remove(peripheral);
                c.SaveChanges();
            }
        }

        public void Edit(int id, string name, string itemno, Status status, int departmentid, int employeeid, DateTime date, string reason) {
            Peripheral peripheral;
            using (Context c = new Context()) {
                peripheral = c.Peripherals.Find(id);
                peripheral.Name = name;
                peripheral.ItemNo = itemno;
                peripheral.Status = status;
                peripheral.DepartmentId = departmentid;
                peripheral.EmployeeId = employeeid;
                peripheral.Date = date;
                peripheral.Reason = reason;

                c.Entry(peripheral).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();
            }
        }

        public static List<Peripheral> Search(string name) {
            using (Context c = new Context()) {
                var search = c.Peripherals
                    .Include(x => x.Employee)
                    .Include(y => y.Department)
                    .Where(b => b.Name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
