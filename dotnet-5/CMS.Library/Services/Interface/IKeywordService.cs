using CMS.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.BL.Services.Interface
{
    public interface IKeywordService
    {
        IEnumerable<Expertise> GetExpertiseByUser(int UserId);
        IEnumerable<Keyword> GetKeyWords();
        Task UpdateExpertise(int UserId, List<Keyword> keywordsToRemove, List<Keyword> KeywordsToAdd);
    }
}