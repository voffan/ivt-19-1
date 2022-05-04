using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


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
                
                for (int i = 1; i <= c.HDDs.Count(); i++)
                {
                    HDD hd = c.HDDs.First(r => r.Id == i);
                    if (hd.ComputerId == comp.Id)
                    {
                        hd.ComputerId = null;
                        c.Entry(hd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        
                    }
                }

                for (int i = 1; i <= c.RAMs.Count(); i++)
                {
                    RAM hd = c.RAMs.First(r => r.Id == i);
                    if (hd.ComputerId == comp.Id)
                    {
                        hd.ComputerId = null;
                        c.Entry(hd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        
                    }
                }

                for (int i = 1; i <= c.Processors.Count(); i++)
                {
                    Processor hd = c.Processors.First(r => r.Id == i);
                    if (hd.ComputerId == comp.Id)
                    {
                        hd.ComputerId = null;
                        c.Entry(hd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        
                    }
                }
                
                c.Remove(comp);
                //c.Entry(comp).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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

                for (int i = 1; i < c.HDDs.Count(); i++)
                {
                    HDD hd = c.HDDs.First(r => r.Id == i);
                    if (hd.ComputerId == comp.Id)
                    {
                        hd.ComputerId = null;
                        c.Entry(hd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                }

                for (int i = 1; i < c.RAMs.Count(); i++)
                {
                    RAM hd = c.RAMs.First(r => r.Id == i);
                    if (hd.ComputerId == comp.Id)
                    {
                        hd.ComputerId = null;
                        c.Entry(hd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                }

                for (int i = 1; i < c.Processors.Count(); i++)
                {
                    Processor hd = c.Processors.First(r => r.Id == i);
                    if (hd.ComputerId == comp.Id)
                    {
                        hd.ComputerId = null;
                        c.Entry(hd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                }


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
