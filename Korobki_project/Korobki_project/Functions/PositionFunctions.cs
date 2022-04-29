using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korobki_project.Classes;

namespace Korobki_project.Functions
{
	class PositionFunctions
	{
        public void Delete(int index)
        {
            Position table;
            using (Context c = new Context())
            {
                table = c.Positions.Find(index);
                c.Remove(table);
                c.SaveChanges();
            }
        }
        public void Edit(int id, string name)
        {
            Position position;
            using (Context c = new Context())
            {
                position = c.Positions.Find(id);
                position.Name = name;
                c.Entry(position).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();

            }
        }
    }
}
