using CMS.DAL.Models;
using System.Collections.Generic;

namespace CMS.Service.Service
{
    public interface IRoleService
    {
        Role GetRoleById(int RoleId);
        IEnumerable<Role> GetRoles();
    }
}