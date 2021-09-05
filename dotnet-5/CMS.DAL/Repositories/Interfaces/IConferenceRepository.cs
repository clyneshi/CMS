using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Interfaces
{
    public interface IConferenceRepository : IRepository
    {
        Task<Conference> AddAsync(Conference Conference);
        Task<List<Conference>> FilterAsync(Expression<Func<Conference, bool>> predicate);
        Task<List<Conference>> GetAllAsync();
        Task<List<Conference>> GetConferencesWithChairAsync(Expression<Func<Conference, bool>> predicate = null);

    }
}