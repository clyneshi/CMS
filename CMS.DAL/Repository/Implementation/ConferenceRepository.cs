using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Implementation
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly CMSDBEntities _context;

        public ConferenceRepository(CMSDBEntities context)
        {
            _context = context;
        }

        public void Add(Conference Conference)
        {
            _context.Conferences.Add(Conference);
        }

        public IEnumerable<Conference> Filter(Expression<Func<Conference, bool>> predicate)
        {
            return _context.Conferences.Where(predicate).ToList();
        }

        public IEnumerable<Conference> GetAll()
        {
            return _context.Conferences.ToList();
        }

        public void Update(Conference Conference)
        {
            _context.Entry(Conference).State = EntityState.Modified;
        }

        public IEnumerable<Conference> GetConferenceWithChair(Expression<Func<Conference, bool>> predicate = null)
        {
            var query = _context.Conferences.Include(x => x.User);

            if (predicate != null)
            {
                query.Where(predicate);
            }

            return query.ToList();
        }
    }
}
