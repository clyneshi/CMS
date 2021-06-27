using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IKeywordRepository
    {
        void Add(Keyword keyword);
        IEnumerable<Keyword> Filter(Expression<Func<Keyword, bool>> predicate);
        IEnumerable<Keyword> GetAll();
        void Update(Keyword keyword);
    }
}