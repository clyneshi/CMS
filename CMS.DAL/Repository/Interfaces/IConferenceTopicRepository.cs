using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Implementation
{
    public interface IConferenceTopicRepository
    {
        void Add(ConferenceTopic ConferenceTopic);
        IEnumerable<ConferenceTopic> Filter(Expression<Func<ConferenceTopic, bool>> predicate);
        IEnumerable<ConferenceTopic> GetAll();
    }
}