using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IConferenceRepository
    {
        void Add(Conference Conference);
        IEnumerable<Conference> Filter(Expression<Func<Conference, bool>> predicate);
        IEnumerable<Conference> GetAll();
        IEnumerable<Conference> GetConferenceWithChair(Expression<Func<Conference, bool>> predicate = null);
        void Update(Conference Conference);
    }
}