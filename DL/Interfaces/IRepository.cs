using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T GetByLogin(string login);
        void Create(T item);
        void Update(T item);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Delete(int id);
    }
}
