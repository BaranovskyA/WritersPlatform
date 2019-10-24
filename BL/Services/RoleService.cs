using BL.BInterfaces;
using BL.BModel;
using BusinessLayer.Utils;
using DataLayer.Interfaces;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork Database { get; set; }

        public RoleService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateOrUpdate(BRoles role)
        {
            if (role.Id == 0)
            {

                Roles drole = new Roles() { Name = role.Name };
                Database.Roles.Create(drole);
            }
            else
            {
                Roles editRole = AutoMapper<BRoles, Roles>.Map(role);
                Database.Roles.Update(editRole);
            }
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public BRoles GetRole(int id)
        {
            if (id != 0)
            {
                return AutoMapper<Roles, BRoles>.Map(Database.Roles.Get, (int)id);
            }
            return new BRoles();
        }

        public IEnumerable<BRoles> GetRoles()
        {
            return AutoMapper<IEnumerable<Roles>, List<BRoles>>.Map(Database.Roles.GetAll);
        }

        public void DeleteRole(int id)
        {
            Database.Roles.Delete(id);
            Database.Save();
        }

    }
}
