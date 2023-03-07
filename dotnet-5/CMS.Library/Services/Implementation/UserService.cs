using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.BL.Enums;
using CMS.BL.Models;
using CMS.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Services.Implementation;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApplicationStrategy _applicationStrategy;

    public UserService(IUnitOfWork unitOfWork, IApplicationStrategy applicationStrategy)
    {
        _unitOfWork = unitOfWork;
        _applicationStrategy = applicationStrategy;
    }

    public async Task<bool> AuthenticateUserAsync(string email, string passWord)
    {
        //TODO: change behavior in accordince with user logic changes 
        // in the past, user - author, reviewer are tied to a single conference
        // after logic changes, author and reviewer can have register in multiple conferences

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(passWord))
            return false;

        var user = (await _unitOfWork.UserRepository
            .FilterAsync(x => x.Email == email && x.Password == passWord))
            .FirstOrDefault();

        if (user == null)
            return false;

        int? conferenceId = null;
        if (user.RoleId == (int)RoleTypesEnum.Author || user.RoleId == (int)RoleTypesEnum.Reviewer)
        {
            var conferenceMembers = (await _unitOfWork.ConferenceMemberRepository
                .FilterAsync(x => x.UserId == user.Id))
                .SingleOrDefault();

            conferenceId = conferenceMembers?.ConferenceId;
        }

        _applicationStrategy.LogInUser(user, conferenceId);

        return true;
    }

    public async Task<int> GetMaxUserIdAsync()
    {
        return (await _unitOfWork.UserRepository.GetAllAsync())
            .OrderByDescending(u => u.Id).FirstOrDefault().Id;
    }

    public async Task UpdateUserAsync(string Name, string Email, string Contact, string oldPasswrd, string newPasswrd)
    {
        // TODO: separate change password validation
        // TODO: pass in user model instead of all fields
        if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email)
            || string.IsNullOrEmpty(oldPasswrd) || string.IsNullOrEmpty(newPasswrd))
        {
            throw new Exception();
        }

        var user = (await _unitOfWork.UserRepository
            .FilterAsync(u => u.Id == _applicationStrategy.GetLoggedInUserInfo().User.Id))
            .FirstOrDefault();
        user.Name = Name;
        user.Email = Email;
        user.Contact = Contact;
        if (user.Password == oldPasswrd)
            user.Password = newPasswrd;

        await _unitOfWork.UserRepository.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IList<User>> GetReviewersAsync(int conferenceId)
    {
        return (await _unitOfWork.ConferenceMemberRepository
            .FilterAsync(x => x.ConferenceId == conferenceId
                    && x.User.RoleId == (int)RoleTypesEnum.Reviewer))
            .Select(x => x.User)
            .ToList();
    }

    public async Task<IList<User>> GetAssignedReviewersByPaperAsync(int paperId)
    {
        return (await _unitOfWork.PaperReviewRepository
            .FilterAsync(x => x.PaperId == paperId))
            .Select(x => x.User)
            .ToList();
    }

    public async Task<IList<UserRoleModel>> GetUsersWithRoleAsync()
    {
        return (await _unitOfWork.UserRepository
            .GetUserWithRoleAsync(null))
            .Select(x => new UserRoleModel
            {
                Id = x.Id,
                Name = x.Name,
                Role = x.Role.Type,
                Email = x.Email,
                Contact = x.Contact
            }).ToList();
    }

    public async Task AddUserAsync(User user)
    {
        if (user == null)
        {
            throw new Exception();
        }

        await _unitOfWork.UserRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }
}
