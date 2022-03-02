using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Autoreport.Models;
using Autoreport.Database;

namespace Autoreport.Services
{
    public class FilmService
    {
        public void Add(string filmName, string filmYear)
        {
            Film film = new Film()
            {
                Name = filmName,
                Year = Convert.ToDateTime(filmYear)
            };

            using (DataContext db = Connection.Connect())
            {
                db.Films.Add(film);
                db.SaveChanges();
            }
        }

        public void Get()
        {

        }

        public List<Film> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Films.ToList();
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
