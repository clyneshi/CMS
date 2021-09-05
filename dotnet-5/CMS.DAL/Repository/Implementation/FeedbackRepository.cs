using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Implementation
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly CmsDbContext _context;

        public FeedbackRepository(CmsDbContext context)
        {
            _context = context;
        }

        public async Task<Feedback> AddAsync(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            return feedback;
        }

        public Task<List<Feedback>> FilterAsync(Expression<Func<Feedback, bool>> predicate)
        {
            return _context.Feedbacks
                .Include(x => x.Paper)
                .Include(x => x.User)
                .Where(predicate)
                .ToListAsync();
        }
    }
}
