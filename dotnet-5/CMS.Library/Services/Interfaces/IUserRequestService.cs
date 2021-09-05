using CMS.DAL.Models;
using CMS.BL.Enums;
using CMS.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.BL.Services.Interfaces
{
    public interface IUserRequestService
    {
        Task AddRegisterRequestAsync(RegisterRequest request);
        Task ChangeRequestStatusAsync(int id, UserRequestStatusEnum Status);
        Task<IList<UserRequestModel>> GetRegisterRequestsForChairAsync(int chairId);
        Task<IList<UserRequestModel>> GetRegisterRequestsForAdminAsync(int adminId);
    }
}