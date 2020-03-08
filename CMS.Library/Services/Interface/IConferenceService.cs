using CMS.DAL.Models;
using CMS.Library.Models;
using System.Collections.Generic;

namespace CMS.Library.Service
{
    public interface IConferenceService
    {
        void AddConference(Conference conference);
        void AddConferenceMember(ConferenceMember conferenceMember);
        void AddConferenceTopic(int conferenceId, IEnumerable<keyword> keywords);
        IEnumerable<Conference> GetConferenceByChair(int chairId);
        Conference GetConferenceById(int? confId);
        IEnumerable<Conference> GetConferences();
        IEnumerable<ConferenceUserModel> GetConferenceChair();
        int GetMaxConferenceId();
        IEnumerable<ReviewerConferenceModel> GetReviewerByConference();
    }
}