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
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Papers.ToList();
            }
        }

        public void AddPaper(Paper paper)
        {
            using (var dbModel = new CMSDBEntities())
            {
                dbModel.Papers.Add(paper);
                dbModel.SaveChanges();
            }
        }

        public Paper GetPaperById(int Id)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Papers.Where(p => p.paperId == Id).SingleOrDefault();
            }
        }

        public List<Paper> GetPapersByAuthor()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Papers.Where(x => x.auId == GlobalVariable.CurrentUser.userId).ToList();
            }
        }

        public List<Paper> GetPapersByConference(int conferenceId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Papers.Where(p => p.confId == conferenceId).ToList();
            }
        }

        public int GetMaxPaperId()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Papers.OrderByDescending(p => p.paperId).FirstOrDefault().paperId;
            }
        }

        public PaperReview GetPaperReview(int paperId, int userId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.PaperReviews.Where(pr => pr.userId == userId && pr.paperId == paperId).SingleOrDefault();
            }
        }

        public void AddPaperReview(PaperReview paperReview)
        {
            using (var dbModel = new CMSDBEntities())
            {
                dbModel.PaperReviews.Add(paperReview);
                dbModel.SaveChanges();
            }
        }

        public void DeletePaperReview(int paperId, int userId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                dbModel.PaperReviews.Remove(dbModel.PaperReviews.Where(pr => pr.userId == userId && pr.paperId == paperId).SingleOrDefault());
                dbModel.SaveChanges();
            }
        }
        public List<ReviewPaperModel> GetReviewPaperList()
        {
            using (var dbModel = new CMSDBEntities())
            {
                var reviewPapers = from p in dbModel.Papers
                                   join pr in dbModel.PaperReviews on p.paperId equals pr.paperId
                                   join cm in dbModel.ConferenceMembers on pr.userId equals cm.userId
                                   where pr.userId == GlobalVariable.CurrentUser.userId && cm.confId == GlobalVariable.UserConference
                                   select new ReviewPaperModel
                                   {
                                       PaperId = p.paperId,
                                       PaperTitle = p.paperTitle,
                                       PaperRating = pr.paperRating
                                   };

                return reviewPapers.ToList();
            }
        }

        public void UpdatePaperStatus(int paperId, string status)
        {
            using (var dbModel = new CMSDBEntities())
            {
                Paper paper = GetPaperById(paperId);
                paper.paperStatus = status;
                dbModel.SaveChanges();
            }
        }

        public void UpdatePaperRating(int paperId, int? rating)
        {
            using (var dbModel = new CMSDBEntities())
            {
                PaperReview pr = dbModel.PaperReviews.FirstOrDefault(p => p.userId == GlobalVariable.CurrentUser.userId && p.paperId == paperId);
                Paper pp = dbModel.Papers.FirstOrDefault(p => p.paperId == paperId);
                if (pr != null)
                {
                    pr.paperRating = rating;
                    pp.paperStatus = "being reviewed";
                    dbModel.SaveChanges();
                }
            }
        }

        public void AddPaperTopic(PaperTopic paperTopic)
        {
            using (var dbModel = new CMSDBEntities())
            {
                dbModel.PaperTopics.Add(paperTopic);
                dbModel.SaveChanges();
            }
        }

        public List<PaperReview> GetPaperReviewByPaper(int paperId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.PaperReviews.Where(pr => pr.paperId == paperId).ToList();
            }
        }

        public List<Feedback> GetFeedbacksByPaper(int paperId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Feedbacks.Where(f => f.paperId == paperId).ToList();
            }
        }

        public List<PaperUserModel> GetPaperUser()
        {
            using (var dbModel = new CMSDBEntities())
            {
                var paper = from p in dbModel.Papers
                            join u in dbModel.Users on p.auId equals u.userId
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
        }

        public List<PaperConferenceModel> GetPaperConferences()
        {
            using (var dbModel = new CMSDBEntities())
            {
                var papers = from p in dbModel.Papers
                             join c in dbModel.Conferences on p.confId equals c.confId
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

        public void AddFeedback(Feedback feedback)
        {
            using (var dbModel = new CMSDBEntities())
            {
                dbModel.Feedbacks.Add(feedback);
                dbModel.SaveChanges();
            }
        }
    }
}
