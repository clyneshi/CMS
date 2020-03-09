using CMS.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Library.Service
{
    public interface IKeywordService
    {
        IEnumerable<Expertise> GetExpertiseByUser(int userId);
        IEnumerable<Keyword> GetKeyWords();
        Task UpdateExpertise(int userId, List<Keyword> keywordsToRemove, List<Keyword> KeywordsToAdd);
    }
}