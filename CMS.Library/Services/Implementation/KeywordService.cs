using CMS.DAL.Models;
using CMS.Library.Global;
using CMS.Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Library.Service
{
    public class KeywordService : IKeywordService
    {
        public IEnumerable<keyword> GetKeyWords()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.keywords.ToList();
            }
        }

        public IEnumerable<keyword> GetKewordsByUser(int userId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Expertises
                    .Where(x => x.userId == userId)
                    .Select(x => x.keyword)
                    .ToList();
            }
        }

        public IEnumerable<Expertise> GetExpertiseByUser(int userId)
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.Expertises.Where(ex => ex.userId == userId).ToList();
            }
        }

        public IEnumerable<ExpertiseKeywordModel> GetExpertiseKeyword()
        {
            using (var dbModel = new CMSDBEntities())
            {
                var kwl = from e in dbModel.Expertises
                          join k in dbModel.keywords on e.keywrdId equals k.keywrdId
                          where e.userId == GlobalVariable.CurrentUser.userId
                          select new ExpertiseKeywordModel
                          {
                              Id = e.Id,
                              KeywrdId = k.keywrdId,
                              KeywrdName = k.keywrdName
                          };

                return kwl.ToList();
            }
        }

        public void UpdateExpertise(List<keyword> keywordsToRemove, List<keyword> KeywordsToAdd)
        {
            using (var dbModel = new CMSDBEntities())
            {
                // TODO: refactor the logic
                var kwl = GetExpertiseKeyword();

                // find removed keywords then remove it
                var tmprmk = new List<keyword>();
                foreach (var k in keywordsToRemove)
                {
                    tmprmk.Add(k);
                }
                foreach (var nk in KeywordsToAdd)
                {
                    foreach (var rk in tmprmk)
                        if (rk.keywrdId == nk.keywrdId)
                            keywordsToRemove.Remove(rk);
                }
                if (keywordsToRemove.Count != 0)
                {
                    foreach (var k in kwl)
                    {
                        foreach (var rk in keywordsToRemove)
                            if (k.KeywrdId == rk.keywrdId)
                                dbModel.Expertises.Remove(dbModel.Expertises.SingleOrDefault(e => e.keywrdId == k.KeywrdId && e.userId == GlobalVariable.CurrentUser.userId));
                    }
                }

                dbModel.SaveChanges();

                // add new keywords
                bool find = false;
                foreach (var k in KeywordsToAdd)
                {
                    find = false;
                    foreach (var ok in kwl)
                        if (ok.KeywrdId == k.keywrdId)
                            find = true;
                    if (!find)
                        dbModel.Expertises.Add(new Expertise { keywrdId = k.keywrdId, userId = GlobalVariable.CurrentUser.userId });
                }
                dbModel.SaveChanges();
            }
        }
    }
}
