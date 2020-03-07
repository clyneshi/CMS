using CMS.Library.Global;
using CMS.Library.Model;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace CMS.Library.Service
{
    public class UserService : IUserService
    {
        // TODO: Use refactory pattern to separate data access from service

        public User AuthenticateUser(string email, string passWord)
        {
            //TODO: change behavior in accordince with user logic changes 
            // in the past, user - author, reviewer are tied to a single conference
            // after logic changes, author and reviewer can have register in multiple conferences

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(passWord))
                return null;
            using (var dbModel = new CMSDBEntities())
            {
                var user = dbModel.Users.FirstOrDefault(x => x.userEmail == email && x.userPasswrd == passWord);

                if (user == null)
                    return null;

                ConferenceMember conferenceMembers;
                if (user.roleId == (int)RoleTypes.Author || user.roleId == (int)RoleTypes.Reviewer)
                {
                    conferenceMembers = dbModel.ConferenceMembers.FirstOrDefault(x => x.userId == user.userId);
                    GlobalVariable.UserConference = conferenceMembers?.confId ?? 0;
                }
                GlobalVariable.CurrentUser = user;

                return user;
            }
        }
        public int GetMaxUserId()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Users.OrderByDescending(u => u.userId).FirstOrDefault().userId;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Users.ToList();
            }
        }

        public void AddUser(User user)
        {
            using (var dbModel = new CMSDBEntities())
            {
                dbModel.Users.Add(user);
                dbModel.SaveChanges();
            }
        }

        public void UpdateUser(string userName, string userEmail, string userContact, string oldPasswrd, string newPasswrd)
        {
            // TODO: Refactor function to receive a user entity to save (repository)
            using (var dbModel = new CMSDBEntities())
            {
                User user = dbModel.Users.FirstOrDefault(u => u.userId == GlobalVariable.CurrentUser.userId);
                user.userName = userName;
                user.userEmail = userEmail;
                user.userContact = userContact;
                if (user.userPasswrd == oldPasswrd)
                    user.userPasswrd = newPasswrd;

                dbModel.SaveChanges();
            }
        }

        public IEnumerable<User> GetReviewers()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.ConferenceMembers
                    .Where(x => x.confId == GlobalVariable.UserConference 
                            && x.User.roleId == (int)RoleTypes.Reviewer)
                    .Select(x => x.User)
                    .ToList();
            }
        }

        public IEnumerable<User> GetReviewersByConference(int conferenceId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.ConferenceMembers
                    .Where(x => x.User.roleId == (int)RoleTypes.Reviewer && x.confId == conferenceId)
                    .Select(x => x.User)
                    .ToList();
            }
        }

        public IEnumerable<User> GetAssignedReviewersByPaper(int paperId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.PaperReviews
                    .Where(x => x.paperId == paperId)
                    .Select(x => x.User)
                    .ToList();
            }
        }

        public IEnumerable<UserRoleModel> GetUserRole()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Users
                    .Include(x => x.Role)
                    .Select(x => new UserRoleModel 
                    {
                        Id = x.userId,
                        Name = x.userName,
                        Role = x.Role.roleType,
                        Email = x.userEmail,
                        Contact = x.userContact
                    }).ToList();
            }
        }
    }
}
