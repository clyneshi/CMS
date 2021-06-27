using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IRegisterRequestRepository
    {
        void Add(RegisterRequest RegisterRequest);
        void Delete(RegisterRequest RegisterRequest);
        IEnumerable<RegisterRequest> Filter(Expression<Func<RegisterRequest, bool>> predicate);
        IEnumerable<RegisterRequest> GetAll();
        void Update(RegisterRequest RegisterRequest);
    }
}