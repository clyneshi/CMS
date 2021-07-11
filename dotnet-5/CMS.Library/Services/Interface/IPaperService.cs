using CMS.DAL.Models;
using CMS.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.BL.Services.Interface
{
    public interface IPaperService
    {
        Task AddPaperAsync(Paper paper, IEnumerable<PaperTopic> paperTopics);
        Task AddPaperReviewAsync(PaperReview paperReview);
        Task DeletePaperReview(int paperId, int UserId);
        Task<IList<Feedback>> GetFeedbacksForPaperAsync(int paperId);
        Task<int> GetMaxPaperIdAsync();
        Task<Paper> GetPaperByIdAsync(int Id);
        Task<IList<PaperConferenceModel>> GetPapersWithConferenceAsync();
        Task<PaperReview> GetPaperReviewAsync(int paperId, int UserId);
        Task<IList<PaperReview>> GetPaperReviewsForPaperAsync(int paperId);
        Task<IList<Paper>> GetPapersForAuthorAsync(int UserId);
        Task<IList<Paper>> GetPapersForConferenceAsync(int conferenceId);
        Task<IList<PaperUserModel>> GetPapersWithAuthorAsync();
        Task<IList<ReviewPaperModel>> GetPapersForReviewAsync(int reviewerId, int conferenceId);
        Task UpdatePaperRatingAsync(int paperId, int rating);
        Task AddFeedbackAsync(Feedback feedback);
    }
}