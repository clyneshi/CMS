using CMS.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Interfaces;

public interface IPaperTopicRepository : IRepository
{
    Task BulkAddAsync(IEnumerable<PaperTopic> topics);
}