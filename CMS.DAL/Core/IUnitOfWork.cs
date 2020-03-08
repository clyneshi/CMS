using CMS.DAL.Repository.Implementation;
using System.Threading.Tasks;

namespace CMS.DAL.Core
{
    /// <summary>
    /// Providers services access to repositories through a shared context
    /// </summary>
    public interface IUnitOfWork
    {
        UserRepository UserRepository { get; }
        ConferenceMemberRepository ConferenceMemberRepository { get; }
        PaperReviewRepository PaperReviewRepository { get; }
        ConferenceRepository ConferenceRepository { get; }
        ConferenceTopicRepository ConferenceTopicRepository { get; }
        KeywordRepository KeywordRepository { get; }
        ExpertiseRepository ExpertiseRepository { get; }

        /// <summary>
        /// Invokes SaveChangesAsync on shared context
        /// </summary>
        Task<int> Save();
    }
}