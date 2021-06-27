using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IExpertiseRepository
    {
        void Add(Expertise Expertise);
        void Delete(Expertise expertise);
        IEnumerable<Expertise> Filter(Expression<Func<Expertise, bool>> predicate);
        IEnumerable<Expertise> GetAll();
    }
}