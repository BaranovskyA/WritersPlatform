using DataLayer.Entities;
using DataLayer.Repository;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Users> Users { get; }
        IRepository<Comments> Comments { get; }
        IRepository<Books> Books { get; }
        IRepository<Genres> Genres { get; }
        IRepository<Roles> Roles { get; }
        IRepository<LogDetail> LogDetails { get; }
        void Save();
    }
}
