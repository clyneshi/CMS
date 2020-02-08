using CMS.Library.Model;
using System.Collections.Generic;

namespace CMS.Library.Service
{
    public interface IKeywordService
    {
        List<Expertise> GetExpertiseByUser(int userId);
        List<ExpertiseKeywordModel> GetExpertiseKeyword();
        List<keyword> GetKewordsByUser(int userId);
        List<keyword> GetKeyWords();
        void UpdateExpertise(List<keyword> keywordsToRemove, List<keyword> KeywordsToAdd);
    }
}