using CMS.DAL.Models;
using CMS.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Implementation;

public class PaperTopicRepository : IPaperTopicRepository
{
    private readonly CmsDbContext _context;

    public PaperTopicRepository(CmsDbContext context)
    {
        _context = context;
    }

    public Task BulkAddAsync(IEnumerable<PaperTopic> topics)
    {
        return _context.PaperTopics.AddRangeAsync(topics);
    }
}
