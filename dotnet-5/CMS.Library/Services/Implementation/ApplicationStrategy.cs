using CMS.DAL.Models;
using CMS.BL.Models;
using CMS.BL.Services.Interfaces;

namespace CMS.BL.Services.Implementation;

public class ApplicationStrategy : IApplicationStrategy
{
    private LoggedInUserModel _user;

    public void LogInUser(User user, int? conferenceId)
    {
        _user = new LoggedInUserModel(user, conferenceId);
    }

    public LoggedInUserModel GetLoggedInUserInfo() => _user;
}
