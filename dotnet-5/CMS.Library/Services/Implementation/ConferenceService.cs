using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.BL.Models;
using CMS.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Services.Implementation;

public class ConferenceService : IConferenceService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApplicationStrategy _applicationStrategy;

    public ConferenceService(IUnitOfWork unitOfWork, IApplicationStrategy applicationStrategy)
    {
        _unitOfWork = unitOfWork;
        _applicationStrategy = applicationStrategy;
    }

    public async Task<IList<Conference>> GetConferencesAsync()
    {
        return await _unitOfWork.ConferenceRepository.GetAllAsync();
    }

    public async Task<Conference> GetConferenceByIdAsync(int ConferenceId)
    {
        return (await _unitOfWork.ConferenceRepository
            .FilterAsync(c => c.Id == ConferenceId))
            .SingleOrDefault();
    }

    public async Task<IList<Conference>> GetConferencesByChairAsync(int ChairId)
    {
        return await _unitOfWork.ConferenceRepository.FilterAsync(c => c.ChairId == ChairId);
    }

    public async Task<IList<ReviewerConferenceModel>> GetReviewersByConferenceAsync()
    {
        // todo: verify conferenceId int => int?
        var conferenceMembers = await _unitOfWork.ConferenceMemberRepository
            .FilterAsync(x => x.Id == _applicationStrategy.GetLoggedInUserInfo().ConferenceId);

        var reviewers = conferenceMembers
            .Select(x => new ReviewerConferenceModel
            {
                Id = x.UserId,
                Name = x.User.Name,
                Role = x.User.Role.Type
            })
            .OrderBy(x => x.Role).ToList();

        return reviewers;
    }


    public async Task<IList<ConferenceUserModel>> GetConferencesWithChairAsync()
    {
        return (await _unitOfWork.ConferenceRepository
            .GetConferencesWithChairAsync())
            .Select(x => new ConferenceUserModel
            {
                Id = x.Id,
                Chair = x.Chair.Name,
                Title = x.Title,
                Location = x.Location,
                BeginDate = x.BeginDate,
                EndDate = x.EndDate,
                PaperDeadline = x.PaperDeadline
            })
            .ToList();
    }

    public async Task<int> GetMaxConferenceIdAsync()
    {
        return (await _unitOfWork.ConferenceRepository
            .GetAllAsync())
            .OrderByDescending(c => c.Id)
            .FirstOrDefault().Id;
    }

    public async Task AddConferenceAsync(Conference conference, IEnumerable<Keyword> keywords)
    {
        if (conference == null)
        {
            throw new Exception();
        }

        if (!keywords.Any())
        {
            throw new Exception();
        }

        var conferenceId = await GetMaxConferenceIdAsync() + 1;

        conference.Id = conferenceId;

        await _unitOfWork.ConferenceRepository.AddAsync(conference);

        foreach (var keyword in keywords)
        {
            await _unitOfWork.ConferenceTopicRepository.AddAsync(new ConferenceTopic
            {
                Id = conferenceId,
                KeywordId = keyword.Id
            });
        }

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddConferenceMemberAsync(int conferenceId, int userId)
    {
        await _unitOfWork.ConferenceMemberRepository.AddAsync(new ConferenceMember
        {
            ConferenceId = conferenceId,
            UserId = userId
        });

        await _unitOfWork.SaveChangesAsync();
    }
}
