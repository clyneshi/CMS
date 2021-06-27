using CMS.DAL.Core;
using CMS.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Service.Service
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Role> GetRoles()
        {
            return _unitOfWork.RoleRepository.GetAll();
        }

        public Role GetRoleById(int RoleId)
        {
            return _unitOfWork.RoleRepository.Filter(r => r.Id == RoleId).SingleOrDefault();
        }
    }
}
