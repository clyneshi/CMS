using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> Filter(Expression<Func<User, bool>> predicate);
        void Add(User user);
        void Update(User user);
    }
}
