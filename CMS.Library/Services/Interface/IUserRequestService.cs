using CMS.DAL.Models;
using CMS.Library.Enums;
using CMS.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Library.Service
{
    public interface IUserRequestService
    {
        Task AddRegisterRequest(RegisterRequest request);
        Task ChangeRequestStatus(int id, UserRequestStatusEnum status);
        IEnumerable<UserRequestModel> GetUserRequestForChair(int chairId);
        IEnumerable<UserRequestModel> GetUserRequestForAdmin(int adminId);
    }
}