using CMS.DAL.Models;
using CMS.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Implementation
{
    public class ExpertiseRepository : IExpertiseRepository
    {
        private readonly CmsDbContext _context;

        public ExpertiseRepository(CmsDbContext context)
        {
            _context = context;
        }

        public async Task<Expertise> AddAsync(Expertise expertise)
        {
            await _context.Expertises.AddAsync(expertise);
            return expertise;
        }

        public Task<List<Expertise>> FilterAsync(Expression<Func<Expertise, bool>> predicate)
        {
            return _context.Expertises
                .Include(x => x.Keyword)
                .Include(x => x.User)
                .Where(predicate)
                .ToListAsync();
        }

        public void Delete(Expertise expertise)
        {
            _context.Expertises.Remove(expertise);
        }
    }
}
