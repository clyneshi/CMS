using CMS.DAL.Models;
using CMS.DAL.Repositories.Interfaces;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Implementation
{
    public class PaperTopicRepository : IPaperTopicRepository
    {
        private readonly CmsDbContext _context;

        public PaperTopicRepository(CmsDbContext context)
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
