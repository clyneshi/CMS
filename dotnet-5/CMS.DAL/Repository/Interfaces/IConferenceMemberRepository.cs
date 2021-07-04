using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IConferenceMemberRepository
    {
        Task<ConferenceMember> AddAsync(ConferenceMember ConferenceMember);
        Task<List<ConferenceMember>> FilterAsync(Expression<Func<ConferenceMember, bool>> predicate);
    }
}