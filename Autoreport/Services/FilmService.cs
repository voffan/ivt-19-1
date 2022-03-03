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
            DateTime year = new DateTime(Int32.Parse(filmYear), 1, 1, 1, 1, 1, 1);

            Film film = new Film()
            {
                Name = filmName,
                Year = year
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

        public List<Film> GetByIds(List<int> ids)
        {
            using (DataContext db = Connection.Connect())
            {
                IQueryable<Film> films = db.Films
                    .Where(f => ids.Any(item => item == f.Id));

                return films.ToList();
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
