using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.Library.Global;
using CMS.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Library.Service
{
    public class PaperService : IPaperService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaperService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            await _unitOfWork.Save();
        }

        public Paper GetPaperById(int Id)
        {
            return _unitOfWork.PaperRepository.Filter(p => p.paperId == Id).SingleOrDefault();
        }

        public IEnumerable<Paper> GetPapersByAuthor(int userId)
        {
            return _unitOfWork.PaperRepository.Filter(x => x.auId == userId);
        }

        public IEnumerable<Paper> GetPapersByConference(int conferenceId)
        {
            return _unitOfWork.PaperRepository.Filter(p => p.confId == conferenceId);
        }

        public int GetMaxPaperId()
        {
            return _unitOfWork.PaperRepository
                .GetAll()
                .OrderByDescending(p => p.paperId)
                .FirstOrDefault().paperId;
        }

        public PaperReview GetPaperReview(int paperId, int userId)
        {
            return _unitOfWork.PaperReviewRepository
                .Filter(pr => pr.userId == userId && pr.paperId == paperId)
                .SingleOrDefault();
        }

        public async Task AddPaperReview(PaperReview paperReview)
        {
            if (paperReview == null)
            {
                throw new Exception();
            }

            _unitOfWork.PaperReviewRepository.Add(paperReview);

            await _unitOfWork.Save();
        }

        public async Task DeletePaperReview(int paperId, int userId)
        {
            var paperReview = _unitOfWork.PaperReviewRepository
                .Filter(pr => pr.userId == userId && pr.paperId == paperId)
                .SingleOrDefault();

            if (paperReview == null)
            {
                throw new Exception();
            }

            _unitOfWork.PaperReviewRepository.Delete(paperReview);

            await _unitOfWork.Save();
        }

        public IEnumerable<ReviewPaperModel> GetPapersForReview(int reviewerId, int conferenceId)
        {
            return _unitOfWork.PaperReviewRepository
                .Filter(x => x.Paper.confId == conferenceId
                    && x.userId == reviewerId)
                .Select(x => new ReviewPaperModel
                {
                    PaperId = x.paperId,
                    PaperTitle = x.Paper.paperTitle,
                    PaperRating = x.paperRating
                }).ToList();
        }

        public async Task UpdatePaperRating(int paperId, int rating)
        {
            var paperReview = _unitOfWork.PaperReviewRepository
                .Filter(p => p.userId == GlobalVariable.CurrentUser.userId && p.paperId == paperId)
                .SingleOrDefault();

            var paper = _unitOfWork.PaperRepository
                .Filter(p => p.paperId == paperId)
                .SingleOrDefault();

            if (paperReview == null || paper == null)
            {
                throw new Exception();
            }

            paperReview.paperRating = rating;
            paper.paperStatus = "being reviewed";

            _unitOfWork.PaperReviewRepository.Update(paperReview);
            _unitOfWork.PaperRepository.Update(paper);

            await _unitOfWork.Save();
        }

        public IEnumerable<PaperReview> GetPaperReviewsByPaper(int paperId)
        {
            return _unitOfWork.PaperReviewRepository.Filter(pr => pr.paperId == paperId).ToList();
        }

        public IEnumerable<Feedback> GetFeedbacksByPaper(int paperId)
        {
            return _unitOfWork.FeedbackRepository.Filter(f => f.paperId == paperId).ToList();
        }

        public IEnumerable<PaperUserModel> GetPapersWithAuthor()
        {
            return _unitOfWork.PaperRepository
                .GetPapersWithAuthorAndConference()
                .Select(x => new PaperUserModel
                {
                    Id = x.paperId,
                    User = x.User.userName,
                    Title = x.paperTitle,
                    Author = x.paperAuthor,
                    SubmisionDate = x.paperSubDate,
                    Length = x.paperLength,
                    Status = x.paperStatus
                })
                .ToList();
        }

        public IEnumerable<PaperConferenceModel> GetPapersWithConference()
        {
            return _unitOfWork.PaperRepository
                .GetPapersWithAuthorAndConference()
                .Select(x => new PaperConferenceModel
                {
                    Id = x.paperId,
                    Title = x.paperTitle,
                    Author = x.paperAuthor,
                    Length = x.paperLength,
                    SubmisionDate = x.paperSubDate
                }).ToList();
        }

        public async Task AddFeedback(Feedback feedback)
        {
            Paper paper = GetPaperById(feedback.paperId);

            if (paper == null)
            {
                throw new Exception();
            }

            feedback.paperId = feedback.paperId;
            _unitOfWork.FeedbackRepository.Add(feedback);

            // TODO: Paper.Stauts might be duplicated with Feedback.fnlDecision
            paper.paperStatus = feedback.fnlDecision;
            _unitOfWork.PaperRepository.Update(paper);

            await _unitOfWork.Save();
        }
    }
}
