using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CMS.DAL.Repository.Interfaces;

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
