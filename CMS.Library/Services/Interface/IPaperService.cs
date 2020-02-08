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
        List<Feedback> GetFeedbacksByPaper(int paperId);
        int GetMaxPaperId();
        Paper GetPaperById(int Id);
        List<PaperConferenceModel> GetPaperConferences();
        PaperReview GetPaperReview(int paperId, int userId);
        List<PaperReview> GetPaperReviewByPaper(int paperId);
        List<Paper> GetPapers();
        List<Paper> GetPapersByAuthor();
        List<Paper> GetPapersByConference(int conferenceId);
        List<PaperUserModel> GetPaperUser();
        List<ReviewPaperModel> GetReviewPaperList();
        void UpdatePaperRating(int paperId, int? rating);
        void UpdatePaperStatus(int paperId, string status);
        void AddFeedback(Feedback feedback);
    }
}