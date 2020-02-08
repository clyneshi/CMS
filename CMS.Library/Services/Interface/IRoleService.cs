using CMS.Library.Model;
using System.Collections.Generic;

namespace CMS.Library.Service
{
    public interface IRoleService
    {
        Role GetRole(int? roleId);
        List<Role> GetRoles();
    }
}