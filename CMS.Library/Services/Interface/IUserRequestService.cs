using CMS.DAL.Models;
using CMS.Service.Enums;
using CMS.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Service.Service
{
    public interface IUserRequestService
    {
        Task AddRegisterRequest(RegisterRequest request);
        Task ChangeRequestStatus(int id, UserRequestStatusEnum Status);
        IEnumerable<UserRequestModel> GetUserRequestForChair(int ChairId);
        IEnumerable<UserRequestModel> GetUserRequestForAdmin(int adminId);
    }
}