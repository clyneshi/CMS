using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.BL.Global;
using CMS.BL.Models;
using CMS.BL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Services.Implementation
{
    public class PaperService : IPaperService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationStrategy _applicationStrategy;

        public PaperService(IUnitOfWork unitOfWork, IApplicationStrategy applicationStrategy)
        {
            _unitOfWork = unitOfWork;
            _applicationStrategy = applicationStrategy;
        }

        public async Task AddPaper(Paper paper, IEnumerable<PaperTopic> paperTopics)
        {
            if (paper == null)
            {
                throw new Exception();
            }

            if (!paperTopics.Any())
            {
                throw new Exception();
            }

            foreach (var topic in paperTopics)
                _unitOfWork.PaperTopicRepository.Add(topic);

            _unitOfWork.PaperRepository.Add(paper);

            await _unitOfWork.SaveChangesAsync();
        }

        public Paper GetPaperById(int Id)
        {
            return _unitOfWork.PaperRepository.Filter(p => p.Id == Id).SingleOrDefault();
        }

        public IEnumerable<Paper> GetPapersByAuthor(int UserId)
        {
            return _unitOfWork.PaperRepository.Filter(x => x.AuthorId == UserId);
        }

        public IEnumerable<Paper> GetPapersByConference(int conferenceId)
        {
            return _unitOfWork.PaperRepository.Filter(p => p.ConferenceId == conferenceId);
        }

        public int GetMaxPaperId()
        {
            return _unitOfWork.PaperRepository
                .GetAll()
                .OrderByDescending(p => p.Id)
                .FirstOrDefault().Id;
        }

        public PaperReview GetPaperReview(int paperId, int UserId)
        {
            return _unitOfWork.PaperReviewRepository
                .Filter(pr => pr.UserId == UserId && pr.PaperId == paperId)
                .SingleOrDefault();
        }

        public async Task AddPaperReview(PaperReview paperReview)
        {
            if (paperReview == null)
            {
                throw new Exception();
            }

            _unitOfWork.PaperReviewRepository.Add(paperReview);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePaperReview(int paperId, int UserId)
        {
            var paperReview = _unitOfWork.PaperReviewRepository
                .Filter(pr => pr.UserId == UserId && pr.PaperId == paperId)
                .SingleOrDefault();

            if (paperReview == null)
            {
                throw new Exception();
            }

            _unitOfWork.PaperReviewRepository.Delete(paperReview);

            await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<ReviewPaperModel> GetPapersForReview(int reviewerId, int conferenceId)
        {
            return _unitOfWork.PaperReviewRepository
                .Filter(x => x.Paper.ConferenceId == conferenceId
                    && x.UserId == reviewerId)
                .Select(x => new ReviewPaperModel
                {
                    PaperId = x.Id,
                    PaperTitle = x.Paper.Title,
                    PaperRating = x.PaperRating
                }).ToList();
        }

        public async Task UpdatePaperRating(int paperId, int rating)
        {
            var paperReview = _unitOfWork.PaperReviewRepository
                .Filter(p => p.UserId == _applicationStrategy.GetLoggedInUserInfo().User.Id && p.Id == paperId)
                .SingleOrDefault();

            var paper = _unitOfWork.PaperRepository
                .Filter(p => p.Id == paperId)
                .SingleOrDefault();

            if (paperReview == null || paper == null)
            {
                throw new Exception();
            }

            paperReview.PaperRating = rating;
            paper.Status = "being reviewed";

            _unitOfWork.PaperReviewRepository.Update(paperReview);
            _unitOfWork.PaperRepository.Update(paper);

            await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<PaperReview> GetPaperReviewsByPaper(int paperId)
        {
            return _unitOfWork.PaperReviewRepository.Filter(pr => pr.PaperId == paperId).ToList();
        }

        public IEnumerable<Feedback> GetFeedbacksByPaper(int paperId)
        {
            return _unitOfWork.FeedbackRepository.Filter(f => f.PaperId == paperId).ToList();
        }

        public IEnumerable<PaperUserModel> GetPapersWithAuthor()
        {
            return _unitOfWork.PaperRepository
                .GetPapersWithAuthorAndConference()
                .Select(x => new PaperUserModel
                {
                    Id = x.Id,
                    User = x.AuthorNavigation.Name,
                    Title = x.Title,
                    Author = x.Author,
                    SubmisionDate = x.SubmissionDate,
                    Length = x.Length,
                    Status = x.Status
                })
                .ToList();
        }

        public IEnumerable<PaperConferenceModel> GetPapersWithConference()
        {
            return _unitOfWork.PaperRepository
                .GetPapersWithAuthorAndConference()
                .Select(x => new PaperConferenceModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    Length = x.Length,
                    SubmisionDate = x.SubmissionDate
                }).ToList();
        }

        public async Task AddFeedback(Feedback feedback)
        {
            if (feedback == null)
            {
                throw new Exception();
            }

            var paper = GetPaperById(feedback.PaperId);

            if (paper == null)
            {
                throw new Exception();
            }

            feedback.PaperId = feedback.PaperId;
            _unitOfWork.FeedbackRepository.Add(feedback);

            paper.Status = feedback.FinalDecision;
            _unitOfWork.PaperRepository.Update(paper);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
