using DataLayer.Interfaces;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repository
{
    public class RoleRepository : IRepository<Roles>
    {
        private Model1 db;

        public RoleRepository(Model1 context)
        {
            this.db = context;
        }

        public void Create(Roles item)
        {
            db.Roles.Add(item);
        }

        public void Delete(int id)
        {
            Roles role = db.Roles.Find(id);
            if (role != null)
                db.Roles.Remove(role);
        }

        public Roles Get(int id)
        {
            return db.Roles.Find(id);
        }

        public IEnumerable<Roles> GetAll()
        {
            return db.Roles;
        }

        public IEnumerable<Roles> Find(Func<Roles, Boolean> predicate)
        {
            return db.Roles.Where(predicate).ToList();
        }

        public void Update(Roles item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Roles GetByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
