using CMS.DAL.Models;
using CMS.Library.Model;
using System.Collections.Generic;

namespace CMS.Library.Service
{
    public interface IUserService
    {
        User AuthenticateUser(string email, string passWord);
        void AddUser(User user);
        IEnumerable<User> GetAssignedReviewersByPaper(int paperId);
        int GetMaxUserId();
        IEnumerable<User> GetReviewers();
        IEnumerable<User> GetReviewersByConference(int conferenceId);
        IEnumerable<UserRoleModel> GetUserRole();
        IEnumerable<User> GetUsers();
        void UpdateUser(string userName, string userEmail, string userContact, string oldPasswrd, string newPasswrd);
    }
}