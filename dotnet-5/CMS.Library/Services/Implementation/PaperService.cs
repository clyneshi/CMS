using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.BL.Models;
using CMS.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Services.Implementation;

public class PaperService : IPaperService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApplicationStrategy _applicationStrategy;

    public PaperService(IUnitOfWork unitOfWork, IApplicationStrategy applicationStrategy)
    {
        _unitOfWork = unitOfWork;
        _applicationStrategy = applicationStrategy;
    }

    public async Task AddPaperAsync(Paper paper, IEnumerable<Keyword> paperTopics)
    {
        if (paper == null)
        {
            throw new Exception();
        }

        if (!paperTopics.Any())
        {
            throw new Exception();
        }

        await _unitOfWork.PaperRepository.AddAsync(paper);

        var topics = paperTopics.Select(x => new PaperTopic
        {
            PaperId = paper.Id,
            Id = x.Id
        }).ToArray();

        await _unitOfWork.PaperTopicRepository.BulkAddAsync(topics);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<Paper> GetPaperByIdAsync(int Id)
    {
        return (await _unitOfWork.PaperRepository.FilterAsync(p => p.Id == Id)).SingleOrDefault();
    }

    public async Task<IList<Paper>> GetPapersForAuthorAsync(int UserId)
    {
        return await _unitOfWork.PaperRepository.FilterAsync(x => x.AuthorId == UserId);
    }

    public async Task<IList<Paper>> GetPapersForConferenceAsync(int conferenceId)
    {
        return await _unitOfWork.PaperRepository.FilterAsync(p => p.ConferenceId == conferenceId);
    }

    public async Task<int> GetMaxPaperIdAsync()
    {
        return (await _unitOfWork.PaperRepository
            .GetAllAsync())
            .OrderByDescending(p => p.Id)
            .FirstOrDefault().Id;
    }

    public async Task<PaperReview> GetPaperReviewAsync(int paperId, int UserId)
    {
        return (await _unitOfWork.PaperReviewRepository
            .FilterAsync(pr => pr.UserId == UserId && pr.PaperId == paperId))
            .SingleOrDefault();
    }

    public async Task AddPaperReviewAsync(PaperReview paperReview)
    {
        if (paperReview == null)
        {
            throw new Exception();
        }

        await _unitOfWork.PaperReviewRepository.AddAsync(paperReview);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeletePaperReview(int paperId, int UserId)
    {
        var paperReview = (await _unitOfWork.PaperReviewRepository
            .FilterAsync(pr => pr.UserId == UserId && pr.PaperId == paperId))
            .SingleOrDefault();

        if (paperReview == null)
        {
            throw new Exception();
        }

        _unitOfWork.PaperReviewRepository.Delete(paperReview);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IList<ReviewPaperModel>> GetPapersForReviewAsync(int reviewerId, int conferenceId)
    {
        return (await _unitOfWork.PaperReviewRepository
            .FilterAsync(x => x.Paper.ConferenceId == conferenceId
                && x.UserId == reviewerId))
            .Select(x => new ReviewPaperModel
            {
                PaperId = x.Id,
                PaperTitle = x.Paper.Title,
                PaperRating = x.PaperRating
            }).ToList();
    }

    public async Task UpdatePaperRatingAsync(int paperId, int rating)
    {
        var paperReview = (await _unitOfWork.PaperReviewRepository
            .FilterAsync(p => p.UserId == _applicationStrategy.GetLoggedInUserInfo().User.Id && p.Id == paperId))
            .SingleOrDefault();

        var paper = (await _unitOfWork.PaperRepository
            .FilterAsync(p => p.Id == paperId))
            .SingleOrDefault();

        if (paperReview == null || paper == null)
        {
            throw new Exception();
        }

        await _unitOfWork.PaperReviewRepository.ChangePaperRatingAsync(paperReview.Id, rating);
        await _unitOfWork.PaperRepository.ChangePaperStatusAsync(paper.Id, "being reviewed");

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IList<PaperReview>> GetPaperReviewsForPaperAsync(int paperId)
    {
        return await _unitOfWork.PaperReviewRepository.FilterAsync(pr => pr.PaperId == paperId);
    }

    public async Task<IList<Feedback>> GetFeedbacksForPaperAsync(int paperId)
    {
        return await _unitOfWork.FeedbackRepository.FilterAsync(f => f.PaperId == paperId);
    }

    public async Task<IList<PaperUserModel>> GetPapersWithAuthorAsync()
    {
        return (await _unitOfWork.PaperRepository
            .GetPapersWithAuthorAndConferenceAsync())
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

    public async Task<IList<PaperConferenceModel>> GetPapersWithConferenceAsync()
    {
        return (await _unitOfWork.PaperRepository
            .GetPapersWithAuthorAndConferenceAsync())
            .Select(x => new PaperConferenceModel
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Length = x.Length,
                SubmisionDate = x.SubmissionDate
            }).ToList();
    }

    public async Task AddFeedbackAsync(Feedback feedback)
    {
        if (feedback == null)
        {
            throw new Exception();
        }

        var paper = await GetPaperByIdAsync(feedback.PaperId);

        if (paper == null)
        {
            throw new Exception();
        }

        feedback.PaperId = feedback.PaperId;
        await _unitOfWork.FeedbackRepository.AddAsync(feedback);

        await _unitOfWork.PaperRepository.ChangePaperStatusAsync(paper.Id, feedback.FinalDecision);

        await _unitOfWork.SaveChangesAsync();
    }
}
