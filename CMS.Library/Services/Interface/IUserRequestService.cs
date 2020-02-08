using CMS.Library.Model;
using System.Collections.Generic;

namespace CMS.Library.Service
{
    public interface IUserRequestService
    {
        bool AddRegisterRequest(RegisterRequest request);
        void ChangeRequestStatus(int id, int type);
        List<UserRequestModel> GetUserRequest();
        List<UserRequestModel> GetUserRequest_Admin();
    }
}