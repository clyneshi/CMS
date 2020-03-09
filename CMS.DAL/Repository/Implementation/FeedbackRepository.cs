using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Implementation
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly CMSDBEntities _context;

        public FeedbackRepository(CMSDBEntities context)
        {
            _context = context;
        }

        public void Add(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
        }

        public IEnumerable<Feedback> Filter(Expression<Func<Feedback, bool>> predicate)
        {
            return _context.Feedbacks
                .Include(x => x.Paper)
                .Include(x => x.User)
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _context.Feedbacks
                .Include(x => x.Paper)
                .Include(x => x.User)
                .ToList();
        }
    }
}
