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
                db.Update(film);
                db.Films.Add(film);
                db.SaveChanges();
            }
        }

        public Film Get(int Id)
        {
            using (DataContext db = Connection.Connect())
            {
                Film film = db.Films
                    .Include(x => x.FilmDirectors)
                    .Include(x => x.FilmCountry)
                    .Include(x => x.Genres)
                .FirstOrDefault(x => x.Id == Id);
                return film;
            }
        }

        public List<Film> GetAll()
        {
            using (DataContext db = Connection.Connect())
            {
                return db.Films.Include(f => f.FilmCountry).ToList();
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

        public void Edit(Film editingEntity, string filmName, DateTime filmDate, int country_id, List<Person> director, List<Genre> genres)
        {
            using (DataContext db = Connection.Connect())
            {
                db.Entry(editingEntity).State = EntityState.Modified;
                editingEntity.Name = filmName;
                editingEntity.Date = filmDate;
                editingEntity.FilmCountry = db.Countries.Find(country_id);
                editingEntity.FilmDirectors = director;
                editingEntity.Genres = genres;
                db.SaveChanges();
            }
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
