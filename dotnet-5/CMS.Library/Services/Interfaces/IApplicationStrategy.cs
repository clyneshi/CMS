using CMS.DAL.Models;
using CMS.BL.Models;

namespace CMS.BL.Services.Interfaces
{
    public interface IApplicationStrategy
    {
        LoggedInUserModel GetLoggedInUserInfo();
        void LogInUser(User user, int? conferenceId);
    }
}