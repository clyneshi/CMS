using CMS.DAL.Models;
using CMS.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.BL.Services.Interface
{
    public interface IConferenceService
    {
        Task AddConferenceAsync(Conference conference, IEnumerable<Keyword> keywords);
        Task AddConferenceMemberAsync(int conferenceId, int userId);
        Task<IList<Conference>> GetConferencesByChairAsync(int ChairId);
        Task<Conference> GetConferenceByIdAsync(int ConferenceId);
        Task<IList<Conference>> GetConferencesAsync();
        Task<IList<ConferenceUserModel>> GetConferencesWithChairAsync();
        Task<int> GetMaxConferenceIdAsync();
        Task<IList<ReviewerConferenceModel>> GetReviewersByConferenceAsync();
    }
}