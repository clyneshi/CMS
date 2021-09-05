using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Interfaces
{
    public interface IFeedbackRepository : IRepository
    {
        Task<Feedback> AddAsync(Feedback Feedback);
        Task<List<Feedback>> FilterAsync(Expression<Func<Feedback, bool>> predicate);
    }
}