using CMS.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.BL.Services.Interface
{
    public interface IRoleService
    {
        Task<Role> GetRoleByIdAsync(int roleId);
        Task<IList<Role>> GetRolesAsync();
    }
}