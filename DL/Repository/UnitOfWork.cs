using DataLayer.Entities;
using DataLayer.Interfaces;
using DL.Entities;
using DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Model1 db;
        private UserRepository userRepository;
        private BooksRepository bookRepository;
        private CommentRepository commentRepository;
        private GenreRepository genreRepository;
        private LogDetailRepository logDetailRepository;
        private RoleRepository roleRepository;
        public UnitOfWork(string connection)
        {
            db = new Model1(connection);
        }

        public IRepository<Users> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Books> Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BooksRepository(db);
                return bookRepository;
            }
        }

        public IRepository<Comments> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        public IRepository<Genres> Genres
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(db);
                return genreRepository;
            }
        }

        public IRepository<Roles> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }

        public IRepository<LogDetail> LogDetails
        {
            get
            {
                if (logDetailRepository == null)
                    logDetailRepository = new LogDetailRepository(db);
                return logDetailRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
