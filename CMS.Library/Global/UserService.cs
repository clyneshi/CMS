using CMS.Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Library.Global
{
    public class UserService : IUserService
    {
        public int GetMaxUserId()
        {
            return GlobalVariable.DbModel.Users.OrderByDescending(u => u.userId).FirstOrDefault().userId;
        }

        public List<User> GetUsers()
        {
            return GlobalVariable.DbModel.Users.ToList();
        }

        public void AddUser(User user)
        {
            GlobalVariable.DbModel.Users.Add(user);
        }

        public void UpdateUser(string userName, string userEmail, string userContact, string oldPasswrd, string newPasswrd)
        {
            User user = GlobalVariable.DbModel.Users.FirstOrDefault(u => u.userId == GlobalVariable.CurrentUser.userId);
            user.userName = userName;
            user.userEmail = userEmail;
            user.userContact = userContact;
            if (user.userPasswrd == oldPasswrd)
                user.userPasswrd = newPasswrd;

            GlobalVariable.DbModel.SaveChanges();
        }

        public List<User> GetReviewers()
        {
            var users = from u in GlobalVariable.DbModel.Users
                        join cf in GlobalVariable.DbModel.ConferenceMembers on u.userId equals cf.userId
                        join c in GlobalVariable.DbModel.Conferences on cf.confId equals c.confId
                        where c.confId == GlobalVariable.UserConference && u.roleId == 3
                        select u;

            return users.ToList();
        }

        public List<User> GetReviewersByConference(int conferenceId)
        {
            var users = from u in GlobalVariable.DbModel.Users
                        join cf in GlobalVariable.DbModel.ConferenceMembers on u.userId equals cf.userId
                        where u.roleId == 3 && cf.confId == conferenceId
                        select u;

            return users.ToList();
        }

        public List<User> GetAssignedReviewersByPaper(int paperId)
        {
            var users = from r in GlobalVariable.DbModel.PaperReviews
                        join u in GlobalVariable.DbModel.Users on r.userId equals u.userId
                        where r.paperId == paperId
                        select u;

            return users.ToList();
        }

        public List<UserRoleModel> GetUserRole()
        {
            var user = from u in GlobalVariable.DbModel.Users
                       join r in GlobalVariable.DbModel.Roles on u.roleId equals r.roleId
                       select new UserRoleModel
                       {
                           Id = u.userId,
                           Name = u.userName,
                           Role = r.roleType,
                           Email = u.userEmail,
                           Contact = u.userContact
                       };

            return user.ToList();
        }
    }
}
