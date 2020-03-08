using CMS.DAL.Models;
using CMS.Library.Models;
using System.Collections.Generic;

namespace CMS.Library.Service
{
    public interface IKeywordService
    {
        IEnumerable<Expertise> GetExpertiseByUser(int userId);
        IEnumerable<ExpertiseKeywordModel> GetExpertiseKeyword();
        IEnumerable<keyword> GetKewordsByUser(int userId);
        IEnumerable<keyword> GetKeyWords();
        void UpdateExpertise(List<keyword> keywordsToRemove, List<keyword> KeywordsToAdd);
    }
}