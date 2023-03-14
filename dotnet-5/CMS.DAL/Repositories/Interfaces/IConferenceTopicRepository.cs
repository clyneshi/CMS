using CMS.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.DAL.Repositories.Interfaces;

public interface IConferenceTopicRepository : IRepository
{
    Task BulkAddAsync(IEnumerable<ConferenceTopic> topics);
}