using CMS.DAL.Models;
using System.Collections.Generic;

namespace CMS.Library.Service
{
    public interface IRoleService
    {
        Role GetRole(int? roleId);
        IEnumerable<Role> GetRoles();
    }
}