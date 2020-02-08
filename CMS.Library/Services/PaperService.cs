using CMS.Library.Global;
using CMS.Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Library.Service
{
    public class PaperService : IPaperService
    {
        public List<Paper> GetPapers()
        {
            return GlobalVariable.DbModel.Papers.ToList();
        }

        public void AddPaper(Paper paper)
        {
            GlobalVariable.DbModel.Papers.Add(paper);
            GlobalVariable.DbModel.SaveChanges();
        }

        public Paper GetPaperById(int Id)
        {
            return GlobalVariable.DbModel.Papers.Where(p => p.paperId == Id).SingleOrDefault();
        }

        public List<Paper> GetPapersByAuthor()
        {
            return GlobalVariable.DbModel.Papers.Where(x => x.auId == GlobalVariable.CurrentUser.userId).ToList();
        }

        public List<Paper> GetPapersByConference(int conferenceId)
        {
            return GlobalVariable.DbModel.Papers.Where(p => p.confId == conferenceId).ToList();
        }

        public int GetMaxPaperId()
        {
            return GlobalVariable.DbModel.Papers.OrderByDescending(p => p.paperId).FirstOrDefault().paperId;
        }

        public PaperReview GetPaperReview(int paperId, int userId)
        {
            return GlobalVariable.DbModel.PaperReviews.Where(pr => pr.userId == userId && pr.paperId == paperId).SingleOrDefault();
        }

        public void AddPaperReview(PaperReview paperReview)
        {
            GlobalVariable.DbModel.PaperReviews.Add(paperReview);
            GlobalVariable.DbModel.SaveChanges();
        }

        public void DeletePaperReview(int paperId, int userId)
        {
            GlobalVariable.DbModel.PaperReviews.Remove(GlobalVariable.DbModel.PaperReviews.Where(pr => pr.userId == userId && pr.paperId == paperId).SingleOrDefault());
            GlobalVariable.DbModel.SaveChanges();
        }
        public List<ReviewPaperModel> GetReviewPaperList()
        {
            var reviewPapers = from p in GlobalVariable.DbModel.Papers
                               join pr in GlobalVariable.DbModel.PaperReviews on p.paperId equals pr.paperId
                               join cm in GlobalVariable.DbModel.ConferenceMembers on pr.userId equals cm.userId
                               where pr.userId == GlobalVariable.CurrentUser.userId && cm.confId == GlobalVariable.UserConference
                               select new ReviewPaperModel
                               {
                                   PaperId = p.paperId,
                                   PaperTitle = p.paperTitle,
                                   PaperRating = pr.paperRating
                               };

            return reviewPapers.ToList();
        }

        public void UpdatePaperStatus(int paperId, string status)
        {
            Paper paper = GetPaperById(paperId);
            paper.paperStatus = status;
            GlobalVariable.DbModel.SaveChanges();
        }

        public void UpdatePaperRating(int paperId, int? rating)
        {
            PaperReview pr = GlobalVariable.DbModel.PaperReviews.FirstOrDefault(p => p.userId == GlobalVariable.CurrentUser.userId && p.paperId == paperId);
            Paper pp = GlobalVariable.DbModel.Papers.FirstOrDefault(p => p.paperId == paperId);
            if (pr != null)
            {
                pr.paperRating = rating;
                pp.paperStatus = "being reviewed";
                GlobalVariable.DbModel.SaveChanges();
            }
        }

        public void AddPaperTopic(PaperTopic paperTopic)
        {
            GlobalVariable.DbModel.PaperTopics.Add(paperTopic);
            GlobalVariable.DbModel.SaveChanges();
        }

        public List<PaperReview> GetPaperReviewByPaper(int paperId)
        {
            return GlobalVariable.DbModel.PaperReviews.Where(pr => pr.paperId == paperId).ToList();
        }

        public List<Feedback> GetFeedbacksByPaper(int paperId)
        {
            return GlobalVariable.DbModel.Feedbacks.Where(f => f.paperId == paperId).ToList();
        }

        public List<PaperUserModel> GetPaperUser()
        {
            var paper = from p in GlobalVariable.DbModel.Papers
                        join u in GlobalVariable.DbModel.Users on p.auId equals u.userId
                        select new PaperUserModel
                        {
                            Id = p.paperId,
                            User = u.userName,
                            Title = p.paperTitle,
                            Author = p.paperAuthor,
                            SubmisionDate = p.paperSubDate,
                            Length = p.paperLength,
                            Status = p.paperStatus
                        };

            return paper.ToList();
        }

        public List<PaperConferenceModel> GetPaperConferences()
        {
            var papers = from p in GlobalVariable.DbModel.Papers
                         join c in GlobalVariable.DbModel.Conferences on p.confId equals c.confId
                         where c.confId == GlobalVariable.UserConference
                         select new PaperConferenceModel
                         {
                             Id = p.paperId,
                             Title = p.paperTitle,
                             Author = p.paperAuthor,
                             Length = p.paperLength,
                             SubmisionDate = p.paperSubDate
                         };

            return papers.ToList();
        }
    }
}
