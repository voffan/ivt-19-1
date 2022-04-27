using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp_park_app.Functions {
    class PositionFunctions {
        public void Add(string name) {
            Position position = new Position() {
                Name = name
            };

            using (Context c = new Context()) {
                c.Positions.Add(position);
                c.SaveChanges();
            }

        }
    }
}
