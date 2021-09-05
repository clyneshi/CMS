using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Interfaces
{
    public interface IExpertiseRepository : IRepository
    {
        Task<Expertise> AddAsync(Expertise Expertise);
        void Delete(Expertise expertise);
        Task<List<Expertise>> FilterAsync(Expression<Func<Expertise, bool>> predicate);
    }
}