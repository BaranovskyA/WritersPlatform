using DataLayer.Entities;
using DataLayer.Interfaces;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class GenreRepository : IRepository<Genres>
    {
        private Model1 db;

        public GenreRepository(Model1 context)
        {
            this.db = context;
        }

        public void Create(Genres item)
        {
            db.Genres.Add(item);
        }

        public void Delete(int id)
        {
            Genres genre = db.Genres.Find(id);
            if (genre != null)
                db.Genres.Remove(genre);
        }

        public Genres Get(int id)
        {
            return db.Genres.Find(id);
        }

        public IEnumerable<Genres> GetAll()
        {
            return db.Genres;
        }

        public IEnumerable<Genres> Find(Func<Genres, Boolean> predicate)
        {
            return db.Genres.Where(predicate).ToList();
        }

        public void Update(Genres item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Genres GetByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
