using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreport.Models
{
    class Director : Person
    {
    }

    class Film
    {
        public int Id { get; }
        public string Name { get; set; }
        public Country FilmCounty { get; set; }
        public Studio FilmStudio { get; set; }
        public Director FilmDirector { get; set; }
        List<Genre> Genres { get; set; }
    }
}