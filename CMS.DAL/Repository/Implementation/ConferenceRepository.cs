using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Implementation
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly CMSContext _context;

        public ConferenceRepository(CMSContext context)
        {
            _context = context;
        }

        public void Add(Conference conference)
        {
            _context.Conferences.Add(conference);
        }

        public IEnumerable<Conference> Filter(Expression<Func<Conference, bool>> predicate)
        {
            return _context.Conferences.Where(predicate).ToList();
        }

        public IEnumerable<Conference> GetAll()
        {
            return _context.Conferences.ToList();
        }

        public void Update(Conference conference)
        {
            _context.Entry(conference).State = EntityState.Modified;
        }

        public IEnumerable<Conference> GetConferenceWithChair(Expression<Func<Conference, bool>> predicate = null)
        {
            var query = _context.Conferences.Include(x => x.Chair);

            if (predicate != null)
            {
                query.Where(predicate);
            }

            return query.ToList();
        }
    }
}
