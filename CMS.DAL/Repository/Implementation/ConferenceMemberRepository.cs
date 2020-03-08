using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CMS.DAL.Repository.Implementation
{
    public class ConferenceMemberRepository : IConferenceMemberRepository
    {
        private readonly CMSDBEntities _context;

        public ConferenceMemberRepository(CMSDBEntities context)
        {
            _context = context;
        }

        public void Add(ConferenceMember ConferenceMember)
        {
            _context.ConferenceMembers.Add(ConferenceMember);
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
