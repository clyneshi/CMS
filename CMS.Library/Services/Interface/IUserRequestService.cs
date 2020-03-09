using CMS.DAL.Models;
using CMS.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Library.Service
{
    public interface IUserRequestService
    {
        Task AddRegisterRequest(RegisterRequest request);
        Task ChangeRequestStatus(int id, UserRequestStatus status);
        IEnumerable<UserRequestModel> GetUserRequestForChair(int chairId);
        IEnumerable<UserRequestModel> GetUserRequestForAdmin(int adminId);
    }
}