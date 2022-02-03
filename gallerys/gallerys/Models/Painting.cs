using System;
using System.Collections.Generic;
using System.Text;

namespace gallerys.Models
{
    internal class Painting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public int Price { get; set; }
        public int status { get; set; }
    }
}
