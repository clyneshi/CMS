using CMS.DAL.Repository.Implementation;
using System.Threading.Tasks;

namespace CMS.DAL.Core
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Providers services access to repositories through a shared context
        /// </summary>
        UserRepository UserRepository { get; }

        /// <summary>
        /// Invokes SaveChangesAsync on shared context
        /// </summary>
        Task<int> Save();
    }
}