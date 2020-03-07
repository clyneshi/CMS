using CMS.Library.Model;
using System.Collections.Generic;

namespace CMS.Library.Service
{
    public interface IPaperService
    {
        void AddPaper(Paper paper);
        void AddPaperReview(PaperReview paperReview);
        void AddPaperTopic(PaperTopic paperTopic);
        void DeletePaperReview(int paperId, int userId);
        IEnumerable<Feedback> GetFeedbacksByPaper(int paperId);
        int GetMaxPaperId();
        Paper GetPaperById(int Id);
        IEnumerable<PaperConferenceModel> GetPaperConferences();
        PaperReview GetPaperReview(int paperId, int userId);
        IEnumerable<PaperReview> GetPaperReviewByPaper(int paperId);
        IEnumerable<Paper> GetPapersByAuthor();
        IEnumerable<Paper> GetPapersByConference(int conferenceId);
        IEnumerable<PaperUserModel> GetPaperUser();
        IEnumerable<ReviewPaperModel> GetReviewPaperList();
        void UpdatePaperRating(int paperId, int? rating);
        void UpdatePaperStatus(int paperId, string status);
        void AddFeedback(Feedback feedback);
    }
}