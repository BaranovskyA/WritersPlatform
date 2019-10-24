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
    public class CommentRepository : IRepository<Comments>
    {

        private Model1 db;

        public CommentRepository(Model1 context)
        {
            this.db = context;
        }

        public void Create(Comments item)
        {
            db.Comments.Add(item);
        }

        public void Delete(int id)
        {
            Comments author = db.Comments.Find(id);
            if (author != null)
                db.Comments.Remove(author);
        }

        public Comments Get(int id)
        {
            return db.Comments.Find(id);
        }

        public IEnumerable<Comments> GetAll()
        {
            List<Comments> z = db.Comments.ToList();
            return z;
        }

        public IEnumerable<Comments> Find(Func<Comments, Boolean> predicate)
        {
            return db.Comments.Where(predicate);
        }

        public void Update(Comments item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Comments GetByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
