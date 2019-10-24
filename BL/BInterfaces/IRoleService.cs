using BL.BModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BInterfaces
{
    public interface IRoleService
    {
        void CreateOrUpdate(BRoles role);
        BRoles GetRole(int id);
        IEnumerable<BRoles> GetRoles();
        void DeleteRole(int id);
        void Dispose();
    }
}
