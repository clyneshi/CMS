using CMS.DAL.Models;
using CMS.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Service.Service
{
    public interface IPaperService
    {
        Task AddPaper(Paper paper, IEnumerable<PaperTopic> paperTopics);
        Task AddPaperReview(PaperReview paperReview);
        Task DeletePaperReview(int paperId, int UserId);
        IEnumerable<Feedback> GetFeedbacksByPaper(int paperId);
        int GetMaxPaperId();
        Paper GetPaperById(int Id);
        IEnumerable<PaperConferenceModel> GetPapersWithConference();
        PaperReview GetPaperReview(int paperId, int UserId);
        IEnumerable<PaperReview> GetPaperReviewsByPaper(int paperId);
        IEnumerable<Paper> GetPapersByAuthor(int UserId);
        IEnumerable<Paper> GetPapersByConference(int conferenceId);
        IEnumerable<PaperUserModel> GetPapersWithAuthor();
        IEnumerable<ReviewPaperModel> GetPapersForReview(int reviewerId, int conferenceId);
        Task UpdatePaperRating(int paperId, int rating);
        Task AddFeedback(Feedback feedback);
    }
}