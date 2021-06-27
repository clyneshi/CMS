using CMS.DAL.Models;
using CMS.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Service.Service
{
    public interface IUserService
    {
        User AuthenticateUser(string email, string passWord);
        Task AddUser(User user);
        IEnumerable<User> GetAssignedReviewersByPaper(int paperId);
        int GetMaxUserId();
        IEnumerable<User> GetReviewers(int conferenceId);
        IEnumerable<UserRoleModel> GetUsersWithRole();
        Task UpdateUser(string Name, string Email, string Contact, string oldPasswrd, string newPasswrd);
    }
}