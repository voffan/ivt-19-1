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

        public void Delete(int index) {
            Position position;
            using (Context c = new Context()) {
                position = c.Positions.Find(index);
                c.Remove(position);
                c.SaveChanges();
            }
        }

        public void Edit(int id, string name) {
            Position position;
            using (Context c = new Context()) {
                position = c.Positions.Find(id);
                position.Name = name;
                c.Entry(position).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                c.SaveChanges();
            }
        }

        public static List<Position> Search(string name) {
            using (Context c = new Context()) {
                var search = c.Positions
                    .Where(b => b.Name.Contains(name))
                    .ToList();
                return search;
            }
        }
    }
}
