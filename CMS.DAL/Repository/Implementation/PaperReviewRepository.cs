using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Implementation
{
    public class PaperReviewRepository : IPaperReviewRepository
    {
        private readonly CMSContext _context;

        public PaperReviewRepository(CMSContext context)
        {
            _context = context;
        }

        public void Add(PaperReview paperReview)
        {
            _context.PaperReviews.Add(paperReview);
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

        public void Delete(PaperReview paperReview)
        {
            _context.PaperReviews.Remove(paperReview);
        }

        public void Update(PaperReview paperReview)
        {
            _context.Entry(paperReview).State = EntityState.Modified;
        }
    }
}
