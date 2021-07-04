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
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly CMSContext _context;

        public ConferenceRepository(CMSContext context)
        {
            _context = context;
        }

        public async Task<Conference> AddAsync(Conference conference)
        {
            await _context.Conferences.AddAsync(conference);
            return conference;
        }

        public Task<List<Conference>> FilterAsync(Expression<Func<Conference, bool>> predicate)
        {
            return _context.Conferences.Where(predicate).ToListAsync();
        }

        public Task<List<Conference>> GetAllAsync()
        {
            return _context.Conferences.ToListAsync();
        }

        public Task<List<Conference>> GetConferencesWithChairAsync(Expression<Func<Conference, bool>> predicate = null)
        {
            var query = _context.Conferences.Include(x => x.Chair);

            if (predicate != null)
            {
                query.Where(predicate);
            }

            return query.ToListAsync();
        }
    }
}
