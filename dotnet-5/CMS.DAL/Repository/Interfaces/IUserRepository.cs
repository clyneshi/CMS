using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IUserRepository : IRepository
    {
        Task<List<User>> GetAllAsync();
        Task<List<User>> FilterAsync(Expression<Func<User, bool>> predicate);
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task<List<User>> GetUserWithRoleAsync(Expression<Func<User, bool>> predicate);
    }
}
