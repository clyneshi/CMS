using CMS.DAL.Models;
using CMS.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Library.Service
{
    public interface IKeywordService
    {
        IEnumerable<Expertise> GetExpertiseByUser(int userId);
        IEnumerable<keyword> GetKeyWords();
        Task UpdateExpertise(int userId, List<keyword> keywordsToRemove, List<keyword> KeywordsToAdd);
    }
}