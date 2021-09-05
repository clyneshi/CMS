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
    public class ConferenceMemberRepository : IConferenceMemberRepository
    {
        private readonly CmsDbContext _context;

        public ConferenceMemberRepository(CmsDbContext context)
        {
            _context = context;
        }

        public async Task<ConferenceMember> AddAsync(ConferenceMember conferenceMember)
        {
            await _context.ConferenceMembers.AddAsync(conferenceMember);
            return conferenceMember;
        }

        public Task<List<ConferenceMember>> FilterAsync(Expression<Func<ConferenceMember, bool>> predicate)
        {
            return _context.ConferenceMembers
                .Include(x => x.Conference)
                .Include(x => x.User)
                .Include(x => x.User.Role)
                .Where(predicate)
                .ToListAsync();
        }

    }
}
