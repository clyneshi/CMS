using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Implementation
{
    public class ConferenceMemberRepository : IConferenceMemberRepository
    {
        private readonly CMSContext _context;

        public ConferenceMemberRepository(CMSContext context)
        {
            _context = context;
        }

        public void Add(ConferenceMember conferenceMember)
        {
            _context.ConferenceMembers.Add(conferenceMember);
        }

        public IEnumerable<ConferenceMember> Filter(Expression<Func<ConferenceMember, bool>> predicate)
        {
            return _context.ConferenceMembers
                .Include(x => x.Conference)
                .Include(x => x.User)
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<ConferenceMember> GetAll()
        {
            return _context.ConferenceMembers
                .Include(x => x.Conference)
                .Include(x => x.User)
                .ToList();
        }
    }
}
