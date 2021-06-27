using CMS.DAL.Models;
using CMS.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Service.Service
{
    public interface IConferenceService
    {
        Task AddConference(Conference conference, IEnumerable<Keyword> keywords);
        Task AddConferenceMember(ConferenceMember conferenceMember);
        IEnumerable<Conference> GetConferencesByChair(int ChairId);
        Conference GetConferenceById(int ConferenceId);
        IEnumerable<Conference> GetConferences();
        IEnumerable<ConferenceUserModel> GetConferenceWithChair();
        int GetMaxConferenceId();
        IEnumerable<ReviewerConferenceModel> GetReviewersByConference();
    }
}