using CMSLibrary.Model;
using System.Collections.Generic;
using System.Linq;

namespace CMSLibrary.Global
{
    public static partial class DataProcessor
    {
        public static List<keyword> GetKeyWords() => GlobalVariable.DbModel.keywords.ToList();

        public static List<keyword> GetKewordsByUser(int userId)
        {
            var expertises = from k in GlobalVariable.DbModel.keywords
                             join e in GlobalVariable.DbModel.Expertises on k.keywrdId equals e.keywrdId
                             where e.userId == userId
                             select k;

            return expertises.ToList();
        }

        public static List<Expertise> GetExpertiseByUser(int userId) => GlobalVariable.DbModel.Expertises.Where(ex => ex.userId == userId).ToList();

        public static List<ExpertiseKeywordModel> GetExpertiseKeyword()
        {
            var kwl = from e in GlobalVariable.DbModel.Expertises
                      join k in GlobalVariable.DbModel.keywords on e.keywrdId equals k.keywrdId
                      where e.userId == GlobalVariable.CurrentUser.userId
                      select new ExpertiseKeywordModel
                      {
                          Id = e.Id,
                          KeywrdId = k.keywrdId,
                          KeywrdName = k.keywrdName
                      };

            return kwl.ToList();
        }

        public static void UpdateExpertise(List<keyword> keywordsToRemove, List<keyword> KeywordsToAdd)
        {
            // TODO: refactor the logic
            var kwl = GetExpertiseKeyword();

            // find removed keywords then remove it
            List<keyword> tmprmk = new List<keyword>();
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
                            GlobalVariable.DbModel.Expertises.Remove(GlobalVariable.DbModel.Expertises.SingleOrDefault(e => e.keywrdId == k.KeywrdId && e.userId == GlobalVariable.CurrentUser.userId));
                }
            }

            GlobalVariable.DbModel.SaveChanges();

            // add new keywords
            bool find = false;
            foreach (var k in KeywordsToAdd)
            {
                find = false;
                foreach (var ok in kwl)
                    if (ok.KeywrdId == k.keywrdId)
                        find = true;
                if (!find)
                    GlobalVariable.DbModel.Expertises.Add(new Expertise { keywrdId = k.keywrdId, userId = GlobalVariable.CurrentUser.userId });
            }
            GlobalVariable.DbModel.SaveChanges();
        }

    }
}
