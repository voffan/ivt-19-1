using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Autoreport.Models;
using Autoreport.Database;
using Microsoft.EntityFrameworkCore;

namespace Autoreport.Services
{
    public class FilmService
    {
        public Film Add(string filmName, int filmYear, Country country, List<Person> director, List<Genre> genres)
        {
            Film film = new Film()
            {
                Name = filmName,
                Year = filmYear,
                FilmCountry = country,
                FilmDirectors = director,
                Genres = genres
            };

            using (DataContext db = Connection.Connect())
            {
                db.Update(film);
                db.Films.Add(film);
                db.SaveChanges();
            }

            return film;
        }

        public Film Get(int filmId)
        {
            using (DataContext db = Connection.Connect())
            {
                Film film = db.Films
                    .Include(x => x.FilmDirectors)
                    .Include(x => x.FilmCountry)
                    .Include(x => x.Genres)
                    .FirstOrDefault(x => x.Id == filmId);
                return film;
            }
        }

        public List<Film> Get(List<int> filmsId)
        {
            using (DataContext db = Connection.Connect())
            {
                IQueryable<Film> films = db.Films
                    .Where(f => filmsId.Any(item => item == f.Id));

                return films.ToList();
            }
        }

        public List<Film> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Films
                    .Include(f => f.Disks)
                    .Include(f => f.FilmCountry)
                    .Include(f => f.FilmDirectors)
                    .Include(f => f.Genres)
                    .ToList();
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
                    .Where(person => (person is not Client && person is not Employee))
                    .ToList();

                return result;
            }
        }

        public void Delete(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Films.Remove(db.Films.First(x => x.Id == Id));
                db.SaveChanges();
            }
        }

        public void Edit(Film editingEntity, string filmName, int filmYear, int countryId, List<Person> directors, List<Genre> genres)
        {
            using (DataContext db = Connection.Connect())
            {
                var film = db.Films
                    .Include(f => f.Genres)
                    .Include(f => f.FilmDirectors)
                    .Where(f => f.Id == editingEntity.Id)
                    .First();

                film.Name = filmName;
                film.Year = filmYear;
                film.FilmCountry = db.Countries.Find(countryId);
                film.FilmDirectors = db.Persons.Where(x => directors.Select(y => y.Id).Contains(x.Id)).ToList();
                film.Genres = db.Genres.Where(x => genres.Select(y => y.Id).Contains(x.Id)).ToList();

                db.SaveChanges();
            }
        }

        internal Person AddDirector(string lastName, string firstName, string middleName)
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

            return FilmDirector;
        }
    }
}
