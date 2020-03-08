using CMS.Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Library.Service
{
    public class RoleService : IRoleService
    {
        public IEnumerable<Role> GetRoles()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Roles.ToList();
            }
        }

        public Role GetRole(int? roleId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Roles.FirstOrDefault(r => r.roleId == roleId);
            }
        }
    }
}
