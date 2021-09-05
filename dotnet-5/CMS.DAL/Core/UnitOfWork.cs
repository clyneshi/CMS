using CMS.DAL.Models;
using CMS.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.DAL.Core
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly CmsDbContext _context;
        private readonly IEnumerable<IRepository> _repositories;
        private readonly IDictionary<Type, IRepository> _instantiatedRepositories;

        public UnitOfWork(CmsDbContext cmsDbContext, IEnumerable<IRepository> repositories)
        {
            _context = cmsDbContext;
            _repositories = repositories;
            _instantiatedRepositories = new Dictionary<Type, IRepository>();
        }

        public IUserRepository UserRepository => GetRepository<IUserRepository>();
        public IConferenceMemberRepository ConferenceMemberRepository => GetRepository<IConferenceMemberRepository>();
        public IPaperReviewRepository PaperReviewRepository => GetRepository<IPaperReviewRepository>();
        public IConferenceRepository ConferenceRepository => GetRepository<IConferenceRepository>();
        public IConferenceTopicRepository ConferenceTopicRepository => GetRepository<IConferenceTopicRepository>();
        public IKeywordRepository KeywordRepository => GetRepository<IKeywordRepository>();
        public IExpertiseRepository ExpertiseRepository => GetRepository<IExpertiseRepository>();
        public IPaperRepository PaperRepository => GetRepository<IPaperRepository>();
        public IFeedbackRepository FeedbackRepository => GetRepository<IFeedbackRepository>();
        public IPaperTopicRepository PaperTopicRepository => GetRepository<IPaperTopicRepository>();
        public IRoleRepository RoleRepository => GetRepository<IRoleRepository>();
        public IRegisterRequestRepository RegisterRequestRepository => GetRepository<IRegisterRequestRepository>();

        internal T GetRepository<T>() where T : class, IRepository
        {
            if (!_instantiatedRepositories.TryGetValue(typeof(T), out var repository))
            {
                repository = _repositories.FirstOrDefault(x => typeof(T).IsInstanceOfType(x));

                if (repository == null)
                    throw new Exception($"Repository {typeof(T).Name} is not registered.");

                _instantiatedRepositories.Add(typeof(T), repository);

            }

            return repository as T;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
