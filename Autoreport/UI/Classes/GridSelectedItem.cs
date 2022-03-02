using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoreport.UI.Classes
{
    class GridSelectedItem
    {
        public int Id { get; set; }
        public string VisibleName { get; set; }

        public override string ToString()
        {
            return VisibleName;
        }
    }
}
