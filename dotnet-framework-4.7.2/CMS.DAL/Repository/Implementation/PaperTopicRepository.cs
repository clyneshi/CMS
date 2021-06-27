using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Implementation
{
    public class PaperTopicRepository : IPaperTopicRepository
    {
        private readonly CMSContext _context;

        public PaperTopicRepository(CMSContext context)
        {
            _context = context;
        }

        public void Add(PaperTopic paperTopic)
        {
            _context.PaperTopics.Add(paperTopic);
        }

        public IEnumerable<PaperTopic> Filter(Expression<Func<PaperTopic, bool>> predicate)
        {
            return _context.PaperTopics
                .Include(x => x.Paper)
                .Include(x => x.Keyword)
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<PaperTopic> GetAll()
        {
            return _context.PaperTopics
                .Include(x => x.Paper)
                .Include(x => x.Keyword)
                .ToList();
        }

        public void Delete(PaperTopic paperTopic)
        {
            _context.PaperTopics.Remove(paperTopic);
        }
    }
}
