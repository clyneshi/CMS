using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IConferenceMemberRepository
    {
        void Add(ConferenceMember ConferenceMember);
        IEnumerable<ConferenceMember> Filter(Expression<Func<ConferenceMember, bool>> predicate);
        IEnumerable<ConferenceMember> GetAll();
    }
}