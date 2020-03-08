using CMS.Library.Global;
using CMS.Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Library.Service
{
    public class PaperService : IPaperService
    {
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

        public IEnumerable<Paper> GetPapersByAuthor()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Papers.Where(x => x.auId == GlobalVariable.CurrentUser.userId).ToList();
            }
        }

        public IEnumerable<Paper> GetPapersByConference(int conferenceId)
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

        public IEnumerable<ReviewPaperModel> GetReviewPaperList()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.ConferenceMembers
                    .Join(
                        dbModel.PaperReviews,
                        x => x.userId,
                        y => y.paperId,
                        (x, y) => new 
                        {
                            ConferenceMembers = x,
                            PaperReview = y
                        }
                    )
                    .Where(z => z.ConferenceMembers.confId == GlobalVariable.UserConference
                        && z.PaperReview.userId == GlobalVariable.CurrentUser.userId)
                    .Select(z => new ReviewPaperModel
                    {
                        PaperId = z.PaperReview.Paper.paperId,
                        PaperTitle = z.PaperReview.Paper.paperTitle,
                        PaperRating = z.PaperReview.paperRating
                    }).ToList();
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

        public IEnumerable<PaperReview> GetPaperReviewByPaper(int paperId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.PaperReviews.Where(pr => pr.paperId == paperId).ToList();
            }
        }

        public IEnumerable<Feedback> GetFeedbacksByPaper(int paperId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Feedbacks.Where(f => f.paperId == paperId).ToList();
            }
        }

        public IEnumerable<PaperUserModel> GetPaperUser()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Papers
                    .Select(x => new PaperUserModel
                    {
                        Id = x.paperId,
                        User = x.User.userName,
                        Title = x.paperTitle,
                        Author = x.paperAuthor,
                        SubmisionDate = x.paperSubDate,
                        Length = x.paperLength,
                        Status = x.paperStatus
                    })
                    .ToList();
            }
        }

        public IEnumerable<PaperConferenceModel> GetPaperConferences()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Papers
                    .Select(x => new PaperConferenceModel
                    {
                        Id = x.paperId,
                        Title = x.paperTitle,
                        Author = x.paperAuthor,
                        Length = x.paperLength,
                        SubmisionDate = x.paperSubDate
                    }).ToList();
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
