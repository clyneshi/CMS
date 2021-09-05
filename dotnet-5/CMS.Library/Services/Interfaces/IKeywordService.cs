using CMS.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.BL.Services.Interfaces
{
    public interface IKeywordService
    {
        Task<IList<Expertise>> GetExpertiseByUserAsync(int UserId);
        Task<IList<Keyword>> GetKeyWordsAsync();
        Task UpdateExpertiseAsync(int UserId, List<Keyword> keywordsToRemove, List<Keyword> KeywordsToAdd);
    }
}