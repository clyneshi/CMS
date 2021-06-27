using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IFeedbackRepository
    {
        void Add(Feedback Feedback);
        IEnumerable<Feedback> Filter(Expression<Func<Feedback, bool>> predicate);
        IEnumerable<Feedback> GetAll();
    }
}