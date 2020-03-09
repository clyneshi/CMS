using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.Library.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Library.Service
{
    public class KeywordService : IKeywordService
    {
        private readonly IUnitOfWork _unitOfWork;

        public KeywordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<keyword> GetKeyWords()
        {
            return _unitOfWork.KeywordRepository.GetAll();
        }

        public IEnumerable<Expertise> GetExpertiseByUser(int userId)
        {
            return _unitOfWork.ExpertiseRepository.Filter(x => x.userId == userId);
        }

        public async Task UpdateExpertise(int userId, List<keyword> keywordsToRemove, List<keyword> KeywordsToAdd)
        {
            if (!keywordsToRemove.Any() && !KeywordsToAdd.Any())
            {
                throw new Exception();
            }

            var removedKeywords = keywordsToRemove.ToList();

            // remove keyword that exists in both add list and remove list
            foreach (var ak in KeywordsToAdd)
            {
                var keywordToDelete = keywordsToRemove.SingleOrDefault(x => x.keywrdId == ak.keywrdId);
                if (keywordToDelete != null)
                    keywordsToRemove.Remove(keywordToDelete);
            }

            var expertises = GetExpertiseByUser(userId);

            // remove keywords
            if (keywordsToRemove.Count != 0)
            {
                foreach (var rk in keywordsToRemove)
                {
                    var expertise = expertises.SingleOrDefault(x => x.keywrdId == rk.keywrdId);
                    if (expertise != null)
                        _unitOfWork.ExpertiseRepository.Delete(expertise);
                }
            }

            // add new keywords
            foreach (var ak in KeywordsToAdd)
            {
                if (expertises.Any(x => x.keywrdId == ak.keywrdId))
                    continue;

                _unitOfWork.ExpertiseRepository.Add(new Expertise
                {
                    keywrdId = ak.keywrdId,
                    userId = GlobalVariable.CurrentUser.userId
                });
            }

            await _unitOfWork.Save();
        }
    }
}
