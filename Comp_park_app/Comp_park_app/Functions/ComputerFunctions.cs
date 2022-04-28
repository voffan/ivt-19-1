using System;
using System.Collections.Generic;
using System.Text;

namespace Comp_park_app.Functions
{
    class ComputerFunctions
    {
        public void Add(int departmentid, string itemno, Status status, int motherboardid,
            int employeeid, List<HDD> hdds, List<RAM> rams, List<Processor> processors)
        {
            Computer comp = new Computer()
            {
                DepartmentId = departmentid,
                ItemNo = itemno,
                Status = status,
                MotherboardId = motherboardid,
                EmployeeId = employeeid,
                //HDDs = hdds,
                //RAMs = rams,
                //Processors = processors
            };

            
            using (Context c = new Context())
            {
                c.Computers.Add(comp);
                c.SaveChanges();
            }
            var id = comp.Id;
            HDD hdd;
            RAM ram;
            Processor processor;

            using (Context c = new Context())
            {
                foreach (var a in hdds)
                {
                    hdd = c.HDDs.Find(a.Id);
                    hdd.ComputerId = id;
                    c.Entry(hdd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                foreach (var a in rams)
                {
                    ram = c.RAMs.Find(a.Id);
                    ram.ComputerId = id;
                    c.Entry(ram).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                foreach (var a in processors)
                {
                    processor = c.Processors.Find(a.Id);
                    processor.ComputerId = id;
                    c.Entry(processor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                c.SaveChanges();
            }
        }

        public void Delete(int index)
        {
            Computer comp;
            using (Context c = new Context())
            {
                comp = c.Computers.Find(index);
                foreach (var i in comp.HDDs)
                {
                    i.ComputerId = null;
                    c.Entry(i).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                foreach (var i in comp.RAMs)
                {
                    i.ComputerId = null;
                    c.Entry(i).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                foreach (var i in comp.Processors)
                {
                    i.ComputerId = null;
                    c.Entry(i).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }



                c.Remove(comp);
                c.SaveChanges();
            }
        }

        public void Edit(int index, int departmentid, string itemno, Status status, int motherboardid,
            int employeeid, List<HDD> hdds, List<RAM> rams, List<Processor> processors)
        {
            Computer comp;
            HDD hdd;
            RAM ram;
            Processor processor;
            using (Context c = new Context())
            {
                comp = c.Computers.Find(index);
                comp.DepartmentId = departmentid;
                comp.ItemNo = itemno;
                comp.Status = status;
                comp.MotherboardId = motherboardid;
                comp.EmployeeId = employeeid;

                // не работает: Object reference not set to an instance of an object. Не удаляет из жестких дисков, оперативок и процессоров айди компьютера
                /*
                 foreach(var i in comp.HDDs)
                {
                        i.ComputerId = null;
                        c.Entry(i).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                   
                }
                foreach (var i in comp.RAMs)
                {
                    i.ComputerId = null;
                        c.Entry(i).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                   
                }
                foreach (var i in comp.Processors)
                {
                   
                        i.ComputerId = null;
                        c.Entry(i).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                     
                }
                 */


                foreach (var a in hdds)
                {
                    hdd = c.HDDs.Find(a.Id);
                    hdd.ComputerId = comp.Id;
                    c.Entry(hdd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                foreach (var a in rams)
                {
                    ram = c.RAMs.Find(a.Id);
                    ram.ComputerId = comp.Id;
                    c.Entry(ram).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                foreach (var a in processors)
                {
                    processor = c.Processors.Find(a.Id);
                    processor.ComputerId = comp.Id;
                    c.Entry(processor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                c.Entry(comp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();
            }
        }
    }
}
