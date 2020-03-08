using CMS.DAL.Models;
using CMS.Library.Global;
using CMS.Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Library.Service
{
    public class ConferenceService : IConferenceService
    {
        public IEnumerable<Conference> GetConferences()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Conferences.ToList();
            }
        }

        public Conference GetConferenceById(int? confId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Conferences.FirstOrDefault(c => c.confId == confId);
            }
        }

        // TODO: make search generic 
        public IEnumerable<Conference> GetConferenceByChair(int chairId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Conferences.Where(c => c.chairId == chairId).ToList();
            }
        }

        public int GetMaxConferenceId()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Conferences.OrderByDescending(c => c.confId).FirstOrDefault().confId;
            }
        }

        public IEnumerable<ReviewerConferenceModel> GetReviewerByConference()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.ConferenceMembers
                    .Where(x => x.confId == GlobalVariable.UserConference)
                    .OrderBy(x => x.User.Role.roleType)
                    .Select(x => new ReviewerConferenceModel
                    {
                        Id = x.userId,
                        Name = x.User.userName,
                        Role = x.User.Role.roleType
                    })
                    .ToList();
            }
        }


        public IEnumerable<ConferenceUserModel> GetConferenceChair()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Conferences
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
        }

        public void AddConference(Conference conference)
        {
            using (var dbModel = new CMSDBEntities())
            {
                dbModel.Conferences.Add(conference);
                dbModel.SaveChanges();
            }
        }

        public void AddConferenceMember(ConferenceMember conferenceMember)
        {
            using (var dbModel = new CMSDBEntities())
            {
                dbModel.ConferenceMembers.Add(conferenceMember);
                dbModel.SaveChanges();
            }
        }

        public void AddConferenceTopic(int conferenceId, IEnumerable<keyword> keywords)
        {
            using (var dbModel = new CMSDBEntities())
            {
                foreach (keyword k in keywords)
                    dbModel.ConferenceTopics.Add(new ConferenceTopic { confId = conferenceId, keywrdId = k.keywrdId });
                dbModel.SaveChanges();
            }
        }
    }
}
