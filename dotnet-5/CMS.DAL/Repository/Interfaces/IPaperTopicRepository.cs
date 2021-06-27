using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IPaperTopicRepository
    {
        void Add(PaperTopic paperTopic);
        void Delete(PaperTopic paperTopic);
        IEnumerable<PaperTopic> Filter(Expression<Func<PaperTopic, bool>> predicate);
        IEnumerable<PaperTopic> GetAll();
    }
}