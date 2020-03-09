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

        public Conference GetConferenceById(int confId)
        {
            return _unitOfWork.ConferenceRepository.Filter(c => c.confId == confId).SingleOrDefault();
        }

        public IEnumerable<Conference> GetConferencesByChair(int chairId)
        {
            return _unitOfWork.ConferenceRepository.Filter(c => c.chairId == chairId);
        }

        public int GetMaxConferenceId()
        {
            return _unitOfWork.ConferenceRepository
                .GetAll()
                .OrderByDescending(c => c.confId)
                .FirstOrDefault().confId;
        }

        public IEnumerable<ReviewerConferenceModel> GetReviewersByConference()
        {
            return _unitOfWork.ConferenceMemberRepository
                .Filter(x => x.confId == GlobalVariable.UserConference)
                .OrderBy(x => x.User.Role.roleType)
                .Select(x => new ReviewerConferenceModel
                {
                    Id = x.userId,
                    Name = x.User.userName,
                    Role = x.User.Role.roleType
                })
                .ToList();
        }


        public IEnumerable<ConferenceUserModel> GetConferenceWithChair()
        {
            return _unitOfWork.ConferenceRepository
                .GetConferenceWithChair()
                .Select(x => new ConferenceUserModel
                {
                    Id = x.confId,
                    Chair = x.User.userName,
                    Title = x.confTitle,
                    Location = x.confLocation,
                    BeginDate = x.confBeginDate,
                    EndDate = x.confEndDate,
                    PaperDeadline = x.paperDeadline
                })
                .ToList();
        }

        public async Task AddConference(Conference conference, IEnumerable<keyword> keywords)
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

            conference.confId = conferenceId;

            _unitOfWork.ConferenceRepository.Add(conference);

            foreach (var keyword in keywords)
            {
                _unitOfWork.ConferenceTopicRepository.Add(new ConferenceTopic
                {
                    confId = conferenceId,
                    keywrdId = keyword.keywrdId
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
