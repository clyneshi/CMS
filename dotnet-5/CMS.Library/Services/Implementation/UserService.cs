using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.BL.Enums;
using CMS.BL.Models;
using CMS.BL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationStrategy _applicationStrategy;

        public UserService(IUnitOfWork unitOfWork, IApplicationStrategy applicationStrategy)
        {
            _unitOfWork = unitOfWork;
            _applicationStrategy = applicationStrategy;
        }

        public bool AuthenticateUser(string email, string passWord)
        {
            //TODO: change behavior in accordince with user logic changes 
            // in the past, user - author, reviewer are tied to a single conference
            // after logic changes, author and reviewer can have register in multiple conferences

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(passWord))
                return false;

            var user = _unitOfWork.UserRepository
                .Filter(x => x.Email == email && x.Password == passWord)
                .FirstOrDefault();

            if (user == null)
                return false;

            int? conferenceId = null;
            if (user.RoleId == (int)RoleTypesEnum.Author || user.RoleId == (int)RoleTypesEnum.Reviewer)
            {
                var conferenceMembers = _unitOfWork.ConferenceMemberRepository
                    .Filter(x => x.UserId == user.Id)
                    .SingleOrDefault();

                conferenceId = conferenceMembers?.ConferenceId;
            }

            _applicationStrategy.LogInUser(user, conferenceId);

            return true;
        }

        public int GetMaxUserId()
        {
            return _unitOfWork.UserRepository.GetAll().OrderByDescending(u => u.Id).FirstOrDefault().Id;
        }

        public async Task UpdateUser(string Name, string Email, string Contact, string oldPasswrd, string newPasswrd)
        {
            // TODO: separate change password validation
            // TODO: pass in user model instead of all fields
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email)
                || string.IsNullOrEmpty(oldPasswrd) || string.IsNullOrEmpty(newPasswrd))
            {
                throw new Exception();
            }

            var user = _unitOfWork.UserRepository
                .Filter(u => u.Id == _applicationStrategy.GetLoggedInUserInfo().User.Id)
                .FirstOrDefault();
            user.Name = Name;
            user.Email = Email;
            user.Contact = Contact;
            if (user.Password == oldPasswrd)
                user.Password = newPasswrd;

            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Save();
        }

        public IEnumerable<User> GetReviewers(int conferenceId)
        {
            return _unitOfWork.ConferenceMemberRepository
                .Filter(x => x.ConferenceId == conferenceId
                        && x.User.RoleId == (int)RoleTypesEnum.Reviewer)
                .Select(x => x.User)
                .ToList();
        }

        public IEnumerable<User> GetAssignedReviewersByPaper(int paperId)
        {
            return _unitOfWork.PaperReviewRepository
                .Filter(x => x.PaperId == paperId)
                .Select(x => x.User)
                .ToList();
        }

        public IEnumerable<UserRoleModel> GetUsersWithRole()
        {
            return _unitOfWork.UserRepository
                .GetUserWithRole(null)
                .Select(x => new UserRoleModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Role = x.Role.Type,
                    Email = x.Email,
                    Contact = x.Contact
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
