using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Implementation
{
    public class KeywordRepository : IKeywordRepository
    {
        private readonly CMSContext _context;

        public KeywordRepository(CMSContext context)
        {
            _context = context;
        }

        public void Add(Keyword keyword)
        {
            _context.Keywords.Add(keyword);
        }

        public IEnumerable<Keyword> Filter(Expression<Func<Keyword, bool>> predicate)
        {
            return _context.Keywords.Where(predicate).ToList();
        }

        public IEnumerable<Keyword> GetAll()
        {
            return _context.Keywords.ToList();
        }

        public void Update(Keyword keyword)
        {
            _context.Entry(keyword).State = EntityState.Modified;
        }
    }
}
