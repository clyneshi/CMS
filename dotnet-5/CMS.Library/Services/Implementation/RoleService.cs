using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.BL.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Services.Implementation;

public class RoleService : IRoleService
{
    private readonly IUnitOfWork _unitOfWork;

    public RoleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IList<Role>> GetRolesAsync()
    {
        return await _unitOfWork.RoleRepository.GetAllAsync();
    }

    public async Task<Role> GetRoleByIdAsync(int roleId)
    {
        return (await _unitOfWork.RoleRepository.FilterAsync(r => r.Id == roleId)).SingleOrDefault();
    }
}
