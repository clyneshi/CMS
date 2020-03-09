using CMS.DAL.Models;
using CMS.DAL.Repository.Implementation;
using CMS.DAL.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace CMS.DAL.Core
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly CMSDBEntities _context;
        private readonly UserRepository _userRepository;
        private readonly ConferenceMemberRepository _conferenceMemberRepository;
        private readonly PaperReviewRepository _paperReview;
        private readonly ConferenceRepository _conferenceRepository;
        private readonly ConferenceTopicRepository _conferenceTopicRepository;
        private readonly KeywordRepository _keywordRepository;
        private readonly ExpertiseRepository _expertiseRepository;
        private readonly PaperRepository _paperRepository;
        private readonly FeedbackRepository _feedbackRepository;
        private readonly PaperTopicRepository _paperTopicRepository;

        public UnitOfWork()
        {
            _context = new CMSDBEntities();
            _userRepository = new UserRepository(_context);
            _conferenceMemberRepository = new ConferenceMemberRepository(_context);
            _paperReview = new PaperReviewRepository(_context);
            _conferenceRepository = new ConferenceRepository(_context);
            _conferenceTopicRepository = new ConferenceTopicRepository(_context);
            _keywordRepository = new KeywordRepository(_context);
            _expertiseRepository = new ExpertiseRepository(_context);
            _paperRepository = new PaperRepository(_context);
            _feedbackRepository = new FeedbackRepository(_context);
            _paperTopicRepository = new PaperTopicRepository(_context);
        }

        public IUserRepository UserRepository => _userRepository;
        public IConferenceMemberRepository ConferenceMemberRepository => _conferenceMemberRepository;
        public IPaperReviewRepository PaperReviewRepository => _paperReview;
        public IConferenceRepository ConferenceRepository => _conferenceRepository;
        public IConferenceTopicRepository ConferenceTopicRepository => _conferenceTopicRepository;
        public IKeywordRepository KeywordRepository => _keywordRepository;
        public IExpertiseRepository ExpertiseRepository => _expertiseRepository;
        public IPaperRepository PaperRepository => _paperRepository;
        public IFeedbackRepository FeedbackRepository => _feedbackRepository;
        public IPaperTopicRepository PaperTopicRepository => _paperTopicRepository;

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
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
