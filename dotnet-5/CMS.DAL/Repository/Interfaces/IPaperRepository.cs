using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IPaperRepository
    {
        void Add(Paper Paper);
        IEnumerable<Paper> Filter(Expression<Func<Paper, bool>> predicate);
        IEnumerable<Paper> GetAll();
        IEnumerable<Paper> GetPapersWithAuthorAndConference(Expression<Func<Paper, bool>> predicate = null);
        void Update(Paper Paper);
    }
}