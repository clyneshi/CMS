using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IKeywordRepository
    {
        void Add(keyword keyword);
        IEnumerable<keyword> Filter(Expression<Func<keyword, bool>> predicate);
        IEnumerable<keyword> GetAll();
        void Update(keyword keyword);
    }
}