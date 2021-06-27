using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.Service.Global;
using CMS.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Service.Service
{
    public class ConferenceService : IConferenceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConferenceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public IEnumerable<ReviewerConferenceModel> GetReviewersByConference()
        {
            return _unitOfWork.ConferenceMemberRepository
                .Filter(x => x.Id == GlobalVariable.UserConference)
                .OrderBy(x => x.User.Role.Type)
                .Select(x => new ReviewerConferenceModel
                {
                    Id = x.UserId,
                    Name = x.User.Name,
                    Role = x.User.Role.Type
                })
                .ToList();
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

            await _unitOfWork.Save();
        }

        public async Task AddConferenceMember(ConferenceMember conferenceMember)
        {
            if (conferenceMember == null)
            {
                throw new Exception();
            }

            _unitOfWork.ConferenceMemberRepository.Add(conferenceMember);

            await _unitOfWork.Save();
        }
    }
}
