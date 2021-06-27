using CMS.DAL.Models;
using CMS.BL.Models;

namespace CMS.BL.Services.Interface
{
    public interface IApplicationStrategy
    {
        LoggedInUserModel GetLoggedInUserInfo();
        void LogInUser(User user, int? conferenceId);
    }
}