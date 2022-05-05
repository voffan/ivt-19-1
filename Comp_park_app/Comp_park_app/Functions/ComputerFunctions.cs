using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Comp_park_app.Functions
{
    class ComputerFunctions
    {
        public void Add(int departmentid, string itemno, Status status, int motherboardid,
            int employeeid, List<HDD> hdds, List<RAM> rams, List<Processor> processors, DateTime date)
        {
            Computer comp = new Computer()
            {
                DepartmentId = departmentid,
                ItemNo = itemno,
                Status = status,
                MotherboardId = motherboardid,
                EmployeeId = employeeid,
                Date = date
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

                foreach (var hd in c.HDDs.ToList())
                {
                    if (hd.ComputerId == comp.Id)
                    {
                        hd.ComputerId = null;
                        c.Entry(hd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        
                    }
                }

                foreach (var rame in c.RAMs.ToList()) 
                {
                    if (rame.ComputerId == comp.Id)
                    {
                        rame.ComputerId = null;
                        c.Entry(rame).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        
                    }
                }

                foreach (var proc in c.RAMs.ToList())
                {
                    if (proc.ComputerId == comp.Id)
                    {
                        proc.ComputerId = null;
                        c.Entry(proc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        
                    }
                }
                
                c.Remove(comp);
                //c.Entry(comp).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                c.SaveChanges();
            }
        }

        public void Edit(int index, int departmentid, string itemno, Status status, int motherboardid,
            int employeeid, List<HDD> hdds, List<RAM> rams, List<Processor> processors, DateTime date)
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
                comp.Date = date;

                foreach (var hd in c.HDDs.ToList())
                {
                    if (hd.ComputerId == comp.Id)
                    {
                        hd.ComputerId = null;
                        c.Entry(hd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    }
                }

                foreach (var rame in c.RAMs.ToList())
                {
                    if (rame.ComputerId == comp.Id)
                    {
                        rame.ComputerId = null;
                        c.Entry(rame).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    }
                }

                foreach (var proc in c.RAMs.ToList())
                {
                    if (proc.ComputerId == comp.Id)
                    {
                        proc.ComputerId = null;
                        c.Entry(proc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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
