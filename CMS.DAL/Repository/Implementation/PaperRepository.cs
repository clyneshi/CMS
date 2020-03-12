using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Implementation
{
    public class PaperRepository : IPaperRepository
    {
        private readonly CMSContext _context;

        public PaperRepository(CMSContext context)
        {
            _context = context;
        }

        public void Add(Paper paper)
        {
            _context.Papers.Add(paper);
        }

        public IEnumerable<Paper> Filter(Expression<Func<Paper, bool>> predicate)
        {
            return _context.Papers.Where(predicate).ToList();
        }

        public IEnumerable<Paper> GetAll()
        {
            return _context.Papers.ToList();
        }

        public void Update(Paper paper)
        {
            _context.Entry(paper).State = EntityState.Modified;
        }

        public IEnumerable<Paper> GetPapersWithAuthorAndConference(Expression<Func<Paper, bool>> predicate = null)
        {
            var query = _context.Papers.Include(x => x.User).Include(x => x.Conference);

            if (predicate != null)
            {
                query.Where(predicate);
            }

            return query.ToList();
        }
    }
}
