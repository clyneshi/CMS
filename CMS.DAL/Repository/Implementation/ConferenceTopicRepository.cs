using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Implementation
{
    public class ConferenceTopicRepository : IConferenceTopicRepository
    {
        private readonly CMSContext _context;

        public ConferenceTopicRepository(CMSContext context)
        {
            _context = context;
        }

        public void Add(ConferenceTopic conferenceTopic)
        {
            _context.ConferenceTopics.Add(conferenceTopic);
        }

        public IEnumerable<ConferenceTopic> Filter(Expression<Func<ConferenceTopic, bool>> predicate)
        {
            return _context.ConferenceTopics
                .Include(x => x.Conference)
                .Include(x => x.Keyword)
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<ConferenceTopic> GetAll()
        {
            return _context.ConferenceTopics
                .Include(x => x.Conference)
                .Include(x => x.Keyword)
                .ToList();
        }
    }
}
