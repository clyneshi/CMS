using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CMS.DAL.Repository.Implementation
{
    public class PaperReviewRepository : IPaperReview
    {
        private readonly CMSDBEntities _context;

        public PaperReviewRepository(CMSDBEntities context)
        {
            _context = context;
        }

        public void Add(PaperReview PaperReview)
        {
            _context.PaperReviews.Add(PaperReview);
        }

        public IEnumerable<PaperReview> Filter(Expression<Func<PaperReview, bool>> predicate)
        {
            return _context.PaperReviews
                .Include(x => x.Paper)
                .Include(x => x.User)
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<PaperReview> GetAll()
        {
            return _context.PaperReviews
                .Include(x => x.Paper)
                .Include(x => x.User)
                .ToList();
        }
    }
}
