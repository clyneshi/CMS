using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.Library.Enums;
using CMS.Library.Global;
using CMS.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Library.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User AuthenticateUser(string email, string passWord)
        {
            //TODO: change behavior in accordince with user logic changes 
            // in the past, user - author, reviewer are tied to a single conference
            // after logic changes, author and reviewer can have register in multiple conferences

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(passWord))
                return null;

            var user = _unitOfWork.UserRepository
                .Filter(x => x.userEmail == email && x.userPasswrd == passWord)
                .FirstOrDefault();

            if (user == null)
                return null;

            if (user.roleId == (int)RoleTypesEnum.Author || user.roleId == (int)RoleTypesEnum.Reviewer)
            {
                var conferenceMembers = _unitOfWork.ConferenceMemberRepository
                    .Filter(x => x.userId == user.userId)
                    .SingleOrDefault();

                GlobalVariable.UserConference = conferenceMembers?.confId ?? 0;
            }

            GlobalVariable.CurrentUser = user;

            return user;
        }

        public int GetMaxUserId()
        {
            return _unitOfWork.UserRepository.GetAll().OrderByDescending(u => u.userId).FirstOrDefault().userId;
        }

        public async Task UpdateUser(string userName, string userEmail, string userContact, string oldPasswrd, string newPasswrd)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userEmail)
                || string.IsNullOrEmpty(oldPasswrd) || string.IsNullOrEmpty(newPasswrd))
            {
                throw new Exception();
            }

            var user = _unitOfWork.UserRepository
                .Filter(u => u.userId == GlobalVariable.CurrentUser.userId)
                .FirstOrDefault();
            user.userName = userName;
            user.userEmail = userEmail;
            user.userContact = userContact;
            if (user.userPasswrd == oldPasswrd)
                user.userPasswrd = newPasswrd;

            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Save();
        }

        public IEnumerable<User> GetReviewers(int conferenceId)
        {
            return _unitOfWork.ConferenceMemberRepository
                .Filter(x => x.confId == conferenceId
                        && x.User.roleId == (int)RoleTypesEnum.Reviewer)
                .Select(x => x.User)
                .ToList();
        }

        public IEnumerable<User> GetAssignedReviewersByPaper(int paperId)
        {
            return _unitOfWork.PaperReviewRepository
                .Filter(x => x.paperId == paperId)
                .Select(x => x.User)
                .ToList();
        }

        public IEnumerable<UserRoleModel> GetUsersWithRole()
        {
            return _unitOfWork.UserRepository
                .GetUserWithRole(null)
                .Select(x => new UserRoleModel
                {
                    Id = x.userId,
                    Name = x.userName,
                    Role = x.Role.roleType,
                    Email = x.userEmail,
                    Contact = x.userContact
                }).ToList();
        }

        public async Task AddUser(User user)
        {
            if (user == null)
            {
                throw new Exception();
            }

            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.Save();
        }
    }
}
