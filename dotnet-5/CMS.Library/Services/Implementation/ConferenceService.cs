using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.BL.Models;
using CMS.BL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Services.Implementation
{
    public class ConferenceService : IConferenceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationStrategy _applicationStrategy;

        public ConferenceService(IUnitOfWork unitOfWork, IApplicationStrategy applicationStrategy)
        {
            _unitOfWork = unitOfWork;
            _applicationStrategy = applicationStrategy;
        }

        public IEnumerable<Conference> GetConferences()
        {
            return _unitOfWork.ConferenceRepository.GetAll();
        }

        public Conference GetConferenceById(int ConferenceId)
        {
            return _unitOfWork.ConferenceRepository.Filter(c => c.Id == ConferenceId).SingleOrDefault();
        }

        public IEnumerable<Conference> GetConferencesByChair(int ChairId)
        {
            return _unitOfWork.ConferenceRepository.Filter(c => c.ChairId == ChairId);
        }

        public int GetMaxConferenceId()
        {
            return _unitOfWork.ConferenceRepository
                .GetAll()
                .OrderByDescending(c => c.Id)
                .FirstOrDefault().Id;
        }

        public async Task<IList<ReviewerConferenceModel>> GetReviewersByConference()
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


        public IEnumerable<ConferenceUserModel> GetConferenceWithChair()
        {
            return _unitOfWork.ConferenceRepository
                .GetConferenceWithChair()
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

        public async Task AddConference(Conference conference, IEnumerable<Keyword> keywords)
        {
            if (conference == null)
            {
                throw new Exception();
            }

            if (!keywords.Any())
            {
                throw new Exception();
            }

            var conferenceId = GetMaxConferenceId() + 1;

            conference.Id = conferenceId;

            _unitOfWork.ConferenceRepository.Add(conference);

            foreach (var keyword in keywords)
            {
                _unitOfWork.ConferenceTopicRepository.Add(new ConferenceTopic
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
}
