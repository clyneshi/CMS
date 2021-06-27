using CMS.DAL.Models;
using CMS.BL.Enums;
using CMS.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.BL.Services.Interface
{
    public interface IUserRequestService
    {
        Task AddRegisterRequest(RegisterRequest request);
        Task ChangeRequestStatus(int id, UserRequestStatusEnum Status);
        IEnumerable<UserRequestModel> GetUserRequestForChair(int ChairId);
        IEnumerable<UserRequestModel> GetUserRequestForAdmin(int adminId);
    }
}