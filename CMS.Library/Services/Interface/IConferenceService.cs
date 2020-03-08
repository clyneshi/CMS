using CMS.DAL.Models;
using CMS.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Library.Service
{
    public interface IConferenceService
    {
        Task AddConference(Conference conference, IEnumerable<keyword> keywords);
        Task AddConferenceMember(ConferenceMember conferenceMember);
        IEnumerable<Conference> GetConferencesByChair(int chairId);
        Conference GetConferenceById(int confId);
        IEnumerable<Conference> GetConferences();
        IEnumerable<ConferenceUserModel> GetConferenceWithChair();
        int GetMaxConferenceId();
        IEnumerable<ReviewerConferenceModel> GetReviewersByConference();
    }
}