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
                HDDs = hdds,
                RAMs = rams,
                Processors = processors
            };

            
            using (Context c = new Context())
            {
                //... initiate field
                c.Computers.Add(comp);
                
                c.SaveChanges();
                
            }
            var id = comp.Id;
            HDD hdd = new HDD();
            RAM ram = new RAM();
            Processor processor = new Processor();

            using (Context c = new Context())
            {
                foreach (var a in hdds)
                {
                    if (c.Entry(hdd).Entity.Id == a.Id)
                    {
                        c.Entry(hdd).Entity.ComputerId = id;
                    }
                }
                foreach (var a in rams)
                {
                    if (c.Entry(ram).Entity.Id == a.Id)
                    {
                        c.Entry(ram).Entity.ComputerId = id;
                    }
                }
                foreach (var a in processors)
                {
                    if (c.Entry(processor).Entity.Id == a.Id)
                    {
                        c.Entry(processor).Entity.ComputerId = id;
                    }
                }
                c.SaveChanges();
            }
        }

        public void Delete()
        {

        }

        public void Edit()
        {

        }
    }
}
