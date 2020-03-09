using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CMS.DAL.Repository.Interfaces;

namespace CMS.DAL.Repository.Implementation
{
    public class PaperTopicRepository : IPaperTopicRepository
    {
        private readonly CMSDBEntities _context;

        public PaperTopicRepository(CMSDBEntities context)
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
                .Include(x => x.keyword)
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<PaperTopic> GetAll()
        {
            return _context.PaperTopics
                .Include(x => x.Paper)
                .Include(x => x.keyword)
                .ToList();
        }

        public void Delete(PaperTopic paperTopic)
        {
            _context.PaperTopics.Remove(paperTopic);
        }
    }
}
