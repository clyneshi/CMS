using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IRoleRepository : IRepository
    {
        Task<List<Role>> FilterAsync(Expression<Func<Role, bool>> predicate);
        Task<List<Role>> GetAllAsync();
    }
}