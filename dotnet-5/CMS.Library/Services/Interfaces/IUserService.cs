using CMS.DAL.Models;
using CMS.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.BL.Services.Interfaces;

public interface IUserService
{
    Task<bool> AuthenticateUserAsync(string email, string passWord);
    Task AddUserAsync(User user);
    Task<IList<User>> GetAssignedReviewersByPaperAsync(int paperId);
    Task<int> GetMaxUserIdAsync();
    Task<IList<User>> GetReviewersAsync(int conferenceId);
    Task<IList<UserRoleModel>> GetUsersWithRoleAsync();
    Task UpdateUserAsync(string Name, string Email, string Contact, string oldPasswrd, string newPasswrd);
}