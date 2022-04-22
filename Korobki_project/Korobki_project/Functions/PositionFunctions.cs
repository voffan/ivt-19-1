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
    }
}
