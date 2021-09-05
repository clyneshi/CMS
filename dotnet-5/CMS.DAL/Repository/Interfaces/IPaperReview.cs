using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IPaperReviewRepository : IRepository
    {
        Task<List<PaperReview>> FilterAsync(Expression<Func<PaperReview, bool>> predicate);
        Task<PaperReview> AddAsync(PaperReview PaperReview);
        void Delete(PaperReview paperReview);
        Task ChangePaperRatingAsync(int paperReviewId, int rating);
    }
}
