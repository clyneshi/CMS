using CMS.DAL.Repositories.Interfaces;
using System.Threading.Tasks;

namespace CMS.DAL.Core
{
    /// <summary>
    /// Providers services access to repositories through a shared context
    /// </summary>
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IConferenceMemberRepository ConferenceMemberRepository { get; }
        IPaperReviewRepository PaperReviewRepository { get; }
        IConferenceRepository ConferenceRepository { get; }
        IConferenceTopicRepository ConferenceTopicRepository { get; }
        IKeywordRepository KeywordRepository { get; }
        IExpertiseRepository ExpertiseRepository { get; }
        IPaperRepository PaperRepository { get; }
        IFeedbackRepository FeedbackRepository { get; }
        IPaperTopicRepository PaperTopicRepository { get; }
        IRoleRepository RoleRepository { get; }
        IRegisterRequestRepository RegisterRequestRepository { get; }

        /// <summary>
        /// Invokes SaveChangesAsync on shared context
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}