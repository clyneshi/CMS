using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Implementation
{
    public class KeywordRepository : IKeywordRepository
    {
        private readonly CMSDBEntities _context;

        public KeywordRepository(CMSDBEntities context)
        {
            _context = context;
        }

        public void Add(keyword keyword)
        {
            _context.keywords.Add(keyword);
        }

        public IEnumerable<keyword> Filter(Expression<Func<keyword, bool>> predicate)
        {
            return _context.keywords.Where(predicate).ToList();
        }

        public IEnumerable<keyword> GetAll()
        {
            return _context.keywords.ToList();
        }

        public void Update(keyword keyword)
        {
            _context.Entry(keyword).State = EntityState.Modified;
        }
    }
}
