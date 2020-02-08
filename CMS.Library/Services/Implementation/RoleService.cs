using CMS.Library.Global;
using CMS.Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Library.Service
{
    public class RoleService : IRoleService
    {
        public List<Role> GetRoles()
        {
            return GlobalVariable.DbModel.Roles.ToList();
        }

        public Role GetRole(int? roleId)
        {
            return GlobalVariable.DbModel.Roles.FirstOrDefault(r => r.roleId == roleId);
        }
    }
}
