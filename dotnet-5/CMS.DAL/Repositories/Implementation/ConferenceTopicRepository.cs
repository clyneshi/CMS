using CMS.DAL.Models;
using CMS.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Implementation;

public class ConferenceTopicRepository : IConferenceTopicRepository
{
    private readonly CmsDbContext _context;

    public ConferenceTopicRepository(CmsDbContext context)
    {
        _context = context;
    }

    public Task BulkAddAsync(IEnumerable<ConferenceTopic> topics)
    {
        return _context.ConferenceTopics.AddRangeAsync(topics);
    }

}
