using CMS.DAL.Models;
using CMS.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Library.Service
{
    public interface IUserService
    {
        User AuthenticateUser(string email, string passWord);
        Task AddUser(User user);
        IEnumerable<User> GetAssignedReviewersByPaper(int paperId);
        int GetMaxUserId();
        IEnumerable<User> GetReviewers(int? conferenceId = null);
        IEnumerable<UserRoleModel> GetUserWithRole();
        Task UpdateUser(string userName, string userEmail, string userContact, string oldPasswrd, string newPasswrd);
    }
}