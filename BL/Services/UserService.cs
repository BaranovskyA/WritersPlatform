using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.BModel;
using DataLayer.Repository;
using DataLayer.Entities;
using DataLayer.Interfaces;
using BusinessLayer.Utils;
using DL.Entities;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateOrUpdate(BUsers user)
        {
            if (user.Id == 0)
            {
                Users duser = new Users() { Login = user.Login, Email = user.Email, IsDeleted = false, Password = user.Password, RoleId = user.RoleId };
                Database.Users.Create(duser);
            } else
            {
                Users editUser = AutoMapper<BUsers, Users>.Map(user);
                Database.Users.Update(editUser);
            }
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public BUsers GetUser(int id)
        {
            if (id != 0)
            {
                return AutoMapper<Users, BUsers>.Map(Database.Users.Get,(int)id);
            }
            return new BUsers();
        }

        public BUsers GetUserByLogin(string login)
        {
            return AutoMapper<Users, BUsers>.Map(Database.Users.GetByLogin, (string)login);
        }

        public IEnumerable<BUsers> GetUsers()
        {
            return AutoMapper<IEnumerable<Users>, List<BUsers>>.Map(Database.Users.GetAll);
        }

        public void DeleteUser(int id)
        {
            Database.Users.Delete(id);
            Database.Save();
        }

    }
}
