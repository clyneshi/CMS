using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Implementation
{
    public class PaperTopicRepository : IPaperTopicRepository
    {
        private readonly CMSContext _context;

        public PaperTopicRepository(CMSContext context)
        {
            _context = context;
        }

        public async Task<PaperTopic> AddAsync(PaperTopic paperTopic)
        {
            await _context.PaperTopics.AddAsync(paperTopic);
            return paperTopic;
        }
    }
}
