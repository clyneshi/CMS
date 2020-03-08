using CMS.DAL.Models;
using CMS.Library.Model;
using System.Collections.Generic;

namespace CMS.Library.Service
{
    public interface IUserRequestService
    {
        void AddRegisterRequest(RegisterRequest request);
        void ChangeRequestStatus(int id, UserRequestStatus status);
        IEnumerable<UserRequestModel> GetUserRequest();
        IEnumerable<UserRequestModel> GetUserRequest_Admin();
    }
}