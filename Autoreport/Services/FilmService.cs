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
        public void Add(string filmName, DateTime filmDate, Country country, List<Person> director, List<Genre> genres)
        {
            Film film = new Film()
            {
                Name = filmName,
                Date = filmDate,
                FilmCountry = country,
                FilmDirectors = director,
                Genres = genres
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

        public List<Genre> GetGenres()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Genres.ToList();
            }
        }

        public List<Country> GetCountries()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Countries.ToList();
            }
        }

        public List<Person> GetFilmsDirectors()
        {
            using (DataContext db = Connection.Connect())
            {
                var result = db.Persons.AsEnumerable()
                    .Where(pers => (pers.GetType() != typeof(Client) && pers.GetType() != typeof(Employee)))
                    .ToList();

                return result;
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

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Films.Remove(db.Films.Where(empl => empl.Id == Id).ToList()[0]);
                db.SaveChanges();
            }
        }

        public void Edit()
        {

        }

        internal void AddDirector(string lastName, string firstName, string middleName)
        {
            Person FilmDirector = new Person()
            {
                Last_name = lastName,
                First_name = firstName,
                Middle_name = middleName
            };

            using (DataContext db = Connection.Connect())
            {
                db.Persons.Add(FilmDirector);
                db.SaveChanges();
            }
        }
    }
}
