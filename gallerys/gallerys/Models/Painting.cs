using System;
using System.Collections.Generic;
using System.Text;

namespace gallerys.Models
{
    public class Painting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public int status { get; set; }
    }
}
