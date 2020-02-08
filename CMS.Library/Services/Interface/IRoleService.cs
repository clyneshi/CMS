using System.Collections.Generic;
using CMS.Library.Model;

namespace CMS.Library.Service
{
    public interface IRoleService
    {
        Role GetRole(int? roleId);
        List<Role> GetRoles();
    }
}