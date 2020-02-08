using CMS.Library.Global;
using CMS.Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Library.Service
{
    public class ConferenceService : IConferenceService
    {
        public List<Conference> GetConferences()
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

        // TODO: make generic search
        public List<Conference> GetConferenceByChair(int chairId)
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

        public List<ReviewerConferenceModel> GetReviewer()
        {
            using (var dbModel = new CMSDBEntities())
            {
                var reviewers = from u in dbModel.Users
                                join cf in dbModel.ConferenceMembers on u.userId equals cf.userId
                                join c in dbModel.Conferences on cf.confId equals c.confId
                                join r in dbModel.Roles on u.roleId equals r.roleId
                                where c.confId == GlobalVariable.UserConference
                                orderby r.roleType
                                select new ReviewerConferenceModel
                                {
                                    Id = u.userId,
                                    Name = u.userName,
                                    Role = r.roleType
                                };

                return reviewers.ToList();
            }
        }


        public List<ConferenceUserModel> GetConferencesUser()
        {
            using (var dbModel = new CMSDBEntities())
            {
                var conf = from c in dbModel.Conferences
                           join u in dbModel.Users on c.chairId equals u.userId
                           select new ConferenceUserModel
                           {
                               Id = c.confId,
                               Chair = u.userName,
                               Title = c.confTitle,
                               Location = c.confLocation,
                               BeginDate = c.confBeginDate,
                               EndDate = c.confEndDate,
                               PaperDeadline = c.paperDeadline
                           };

                return conf.ToList();
            }
        }

        public void AddConference(Conference conference)
        {
            using (var dbModel = new CMSDBEntities())
            {
                dbModel.Conferences.Add(conference);
            }
        }

        public List<ConferenceMember> GetConferenceMembers()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.ConferenceMembers.ToList();
            }
        }

        public void AddConferenceMember(ConferenceMember conferenceMember)
        {
            using (var dbModel = new CMSDBEntities())
            {
                dbModel.ConferenceMembers.Add(conferenceMember);
            }
        }

        public void AddConferenceTopic(int conferenceId, List<keyword> keywords)
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
