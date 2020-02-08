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
            return GlobalVariable.DbModel.Conferences.ToList();
        }

        public Conference GetConferenceById(int? confId)
        {
            return GlobalVariable.DbModel.Conferences.FirstOrDefault(c => c.confId == confId);
        }

        // TODO: make generic search
        public List<Conference> GetConferenceByChair(int chairId)
        {
            return GlobalVariable.DbModel.Conferences.Where(c => c.chairId == chairId).ToList();
        }

        public int GetMaxConferenceId()
        {
            return GlobalVariable.DbModel.Conferences.OrderByDescending(c => c.confId).FirstOrDefault().confId;
        }

        public List<ReviewerConferenceModel> GetReviewer()
        {
            var reviewers = from u in GlobalVariable.DbModel.Users
                            join cf in GlobalVariable.DbModel.ConferenceMembers on u.userId equals cf.userId
                            join c in GlobalVariable.DbModel.Conferences on cf.confId equals c.confId
                            join r in GlobalVariable.DbModel.Roles on u.roleId equals r.roleId
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


        public List<ConferenceUserModel> GetConferencesUser()
        {
            var conf = from c in GlobalVariable.DbModel.Conferences
                       join u in GlobalVariable.DbModel.Users on c.chairId equals u.userId
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

        public void AddConference(Conference conference)
        {
            GlobalVariable.DbModel.Conferences.Add(conference);
        }

        public List<ConferenceMember> GetConferenceMembers()
        {
            return GlobalVariable.DbModel.ConferenceMembers.ToList();
        }

        public void AddConferenceMember(ConferenceMember conferenceMember)
        {
            GlobalVariable.DbModel.ConferenceMembers.Add(conferenceMember);
        }

        public void AddConferenceTopic(int conferenceId, List<keyword> keywords)
        {
            foreach (keyword k in keywords)
                GlobalVariable.DbModel.ConferenceTopics.Add(new ConferenceTopic { confId = conferenceId, keywrdId = k.keywrdId });
            GlobalVariable.DbModel.SaveChanges();
        }

    }
}
