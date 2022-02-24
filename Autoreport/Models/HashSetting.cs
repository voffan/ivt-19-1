using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoreport.Models
{
    public class HashSetting
    {
        public int Id { get; set; }
        public int SaltSize { get; set; }
        public int HashSize { get; set; }
        public string Salt { get; set; }
        public int Iterations { get; set; }
    }
}
