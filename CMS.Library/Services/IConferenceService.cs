using System.Collections.Generic;
using CMS.Library.Model;

namespace CMS.Library.Service
{
    public interface IConferenceService
    {
        void AddConference(Conference conference);
        void AddConferenceMember(ConferenceMember conferenceMember);
        void AddConferenceTopic(int conferenceId, List<keyword> keywords);
        List<Conference> GetConferenceByChair(int chairId);
        Conference GetConferenceById(int? confId);
        List<ConferenceMember> GetConferenceMembers();
        List<Conference> GetConferences();
        List<ConferenceUserModel> GetConferencesUser();
        int GetMaxConferenceId();
        List<ReviewerConferenceModel> GetReviewer();
    }
}