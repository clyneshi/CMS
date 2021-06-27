using CMS.DAL.Models;
using System.Collections.Generic;

namespace CMS.BL.Services.Interface
{
    public interface IRoleService
    {
        Role GetRoleById(int RoleId);
        IEnumerable<Role> GetRoles();
    }
}